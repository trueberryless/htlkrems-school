// -- ---------------------------------------------------------------------- --
// --  1.Beispiel) aggregate
// -- ---------------------------------------------------------------------- --
// Erstellen Sie für jede Story Section einen Report, der ungefähr so aussehen sollte:

//  var section = {
//      book: "Flight from the dark",
//      sectionNr: 11,
//      region: "Kings Citadel",
//      content: "You quickly dodge into the doorway of a stable and hide your surgeon’s cloak in the straw, for it would be better to be seen as a Kai Lord than as a charlatan. Without wasting a second, you set off towards the Great Hall on the other side of the courtyard.",
//      arrivalCount: 4, // How many sections lead to this section?
//      departureCount: 3 // How many outcomes has this section?
//  }

// Speichern Sie all diese Daten im SectionReport!

use playbooks;
db.lw1.find();

db.lw1.aggregate([
    {
        $match: {
            sectionType: "STORY_SECTION"
        }
    },
    {
        $lookup: {
            from: "lw1",
            let: {
                sectionNr: "$sectionNr"
            },
            pipeline: [
                {
                    $match: {
                        sectionType: "STORY_SECTION"
                    }
                },
                {
                    $unwind: "$outcomes"
                },
                {
                    $match: {
                        $expr: {
                            $eq: [ "$$sectionNr", "$outcomes.targetNr" ]
                        }
                    }
                },
                {
                    $count: "outcomeCount"
                }
            ],
            as: "arrivalCount"
        }
    },
    {
        $addFields: {
            arrivalCount: {
                $first: "$arrivalCount.outcomeCount"
            }
        }
    }
]);


// -- ---------------------------------------------------------------------- --
// --  2. Beispiel) aggregate
// -- ---------------------------------------------------------------------- --
// Gib alle Story Sections aus, welche einen Outcome Six Senth haben

db.lw1.find();

db.lw1.aggregate([
    {
        $match: {
            sectionType: "STORY_SECTION"
        }
    },
    {
        $addFields: {
            filteredOutcomes: {
                $filter: {
                    input: "$outcomes",
                    as: "outcome",
                    cond: {
                        $eq: [ "$$outcome.ability.abilityType", "SIXTH_SENSE" ]
                    }
                }
            }
        }
    },
    {
        $match: {
            $expr: {
                $and: [
                    {
                        $ne: [ "$filteredOutcomes", [] ]
                    },
                    {
                        $ne: [ "$filteredOutcomes", null ]
                    }
                ]
            }
        }
    },
    {
        $project: {
            filteredOutcomes: 0
        }
    }
]);

// -- ---------------------------------------------------------------------- --
// --  3. Beispiel) aggregate
// -- ---------------------------------------------------------------------- --
// In welchen Regions wird am meisten gekämpft?

db.lw1.find();

db.lw1.aggregate([
    {
        $match: {
            sectionType: "STORY_SECTION"
        }
    },
    {
        $unwind: "$region"
    },
    {
        $group:{
            _id: "$region",
            events: {
                $push: "$events"
            }
        }
    },
    {
        $addFields: {
            combatEvents: {
                $map: {
                    input: "$events",
                    as: "events",
                    in: {
                        $filter: {
                            input: "$$events",
                            as: "event",
                            cond: {
                                $eq: [ "$$event.eventType", "COMBAT" ]
                            }
                        }
                    }
                }
            }
        }
    },
    {
        $project: {
            _id: 0,
            region: "$_id",
            combatCount: {
                $size: "$combatEvents"
            }
        }
    },
    {
        $match: {
            $expr: {
                $ne: [ "$region", "Sommerlund Woodlands" ]
            }
        }
    },
    {
        $group: {
            _id: null,
            maxCombatCount: {
                $max: "$combatCount"
            },
            regions: {
                $push: {
                    name: "$region",
                    combatCount: "$combatCount"
                }
            }
        }
    },
    {
        $addFields: {
            regions: {
                $filter: {
                    input: "$regions",
                    as: "region",
                    cond: {
                        $eq: [ "$$region.combatCount", "$maxCombatCount" ]
                    }
                }
            }
        }
    },
    {
        $unwind: "$regions"
    },
    {
        $replaceRoot: {
            newRoot: "$regions"
        }
    },
    {
        $out: "maxCombats"
    }
]);

// -- ---------------------------------------------------------------------- --
// --  4. Beispiel) aggregate
// -- ---------------------------------------------------------------------- --
// In welchen Subregions wird am meisten gekämpft? Beachte nur Regions, die keine Subregions mehr beinhalten!

// unsolved yet

// -- ---------------------------------------------------------------------- --
// --  5. Beispiel) aggregate
// -- ---------------------------------------------------------------------- --
// In welcher Region bekommt man die meisten Items?

db.lw1.find();

db.lw1.aggregate([
    {
        $match: {
            sectionType: "STORY_SECTION",
            events: { $exists: true }
        }
    },
    {
        $addFields: {
            acquireItemCount: {
                $reduce: {
                    input: "$events",
                    initialValue: 0,
                    in: {
                        $cond: {
                            if: {
                                $eq: [ "$$this.eventType", "ACQUIRE_ITEM_EVENT" ]
                            },
                            then: {
                                $add: [ "$$value", 1 ]
                            } ,
                            else: "$$value"
                        }
                    }
                }
            }
        }
    },
    {
        $group: {
            _id: "$region.name",
            acquireItemCount: {
                $sum: "$acquireItemCount"
            }
        }
    },
    {
        $group: {
            _id: null,
            maxAcquireItemCount: {
                $max: "$acquireItemCount"
            },
            regions: {
                $addToSet: "$$CURRENT"
            }
        }
    },
    {
        $addFields: {
            regions: {
                $filter: {
                    input: "$regions",
                    as: "region",
                    cond: {
                        $eq: [ "$maxAcquireItemCount", "$$region.acquireItemCount" ]
                    }
                }
            }
        }
    },
    {
        $unwind: "$regions"
    },
    {
        $replaceRoot: {
            newRoot: "$regions"
        }
    },
    {
        $out: "maxAcquireItemRegion"
    }
]);

// -- ---------------------------------------------------------------------- --
// --  6. Beispiel) aggregate
// -- ---------------------------------------------------------------------- --
// Welche Items können nicht acquired werden?

db.lw1.find();

db.lw1.aggregate([
    {
        $lookup: {
            from: "lw1",
            let: {},
            pipeline: [
                {
                    $match: {
                        ruleType: "ITEMS"
                    }
                },
                {
                    $unwind: "$items"
                },
                {
                    $project: {
                        _id: 0,
                        item: "$items.name"
                    }
                }
            ],
            as: "allItems"
        }
    },
    {
        $addFields: {
            allItems: "$allItems.item"
        }
    },
    {
        $match: {
            events: {
                $exists: true
            }
        }
    },
    {
        $project: {
            events: 1,
            allItems: 1
        }
    },
    {
        $unwind: "$events"
    },
    {
        $group: {
            _id: null,
            allItems: {
                $first: "$allItems"
            },
            events: {
                $push: "$events"
            }
        }
    },
    {
        $addFields: {
            events: {
                $filter: {
                    input: "$events",
                    as: "event",
                    cond: {
                        $eq: [ "$$event.eventType", "ACQUIRE_ITEM_EVENT" ]
                    }
                }
            }
        }
    },
    {
        $addFields: {
            events: {
                $reduce: {
                    input: "$events",
                    initialValue: [],
                    in: {
                        $cond: {
                            if: {
                                $in: [ "$$this.item.name", "$$value" ]
                            },
                            then: "$$value",
                            else: {
                                $concatArrays: [ "$$value", [ "$$this.item.name" ]]
                            }
                        }
                    }
                }
            }
        }
    },
    {
        $addFields: {
            notAcquireableItems: {
                $filter: {
                    input: "$allItems",
                    as: "allItem",
                    cond: {
                        $not: {
                            $in: [ "$$allItem", "$events" ]
                        }
                    }
                }
            },
            notListedItems: {
                $filter: {
                    input: "$events",
                    as: "event",
                    cond: {
                        $not: {
                            $in: [ "$$event", "$allItems" ]
                        }
                    }
                }
            }
        }
    }
]);

db.lw1.aggregate([

]);

db.lw1.aggregate([
    {
        $match: {
            events: {$exists: true}
        }
    }
]);