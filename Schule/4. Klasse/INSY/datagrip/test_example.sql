use playbooks;

db.lw1.find({sectionType: "STORY_SECTION", events: {$exists: true}});

/*db.lw1.aggregate([
    {
        $match: {
            sectionType: "STORY_SECTION"
        }
    },
    {
        $lookup: {
            from: "lw1",
            let: {},
            pipeline: [

            ],
            as: {

            }
        }
    }
]);*/

db.lw1.aggregate([
    {
        $match: {
            sectionType: "STORY_SECTION",
            outcomes: { $exists: true }
        }
    },
    {
        $lookup: {
            from: "lw1",
            localField: "sectionNr",
            foreignField: "outcomes.targetNr",
            as: "nextSections"
        }
    },
    {
        $addFields: {
            nextSections: {
                $filter: {
                    input: "$nextSections",
                    as: "nextSection",
                    cond: {
                        $and: [/*
                            {
                                $eq: [ "$$nextSection.sectionType", "STORY_SECTION" ]
                            },*/
                            {
                                /*$let: {
                                    vars: {
                                        event: {
                                            $first: "$$nextSection.events"
                                        }
                                    },
                                    in: {
                                        $in: [ "$$event.eventType", [ "MISSION_FAILED_EVENT", "MISSION_ACCOMPLISHED_EVENT" ] ]
                                    }
                                }*/

                                $or: [
                                    {
                                        $map: {
                                            input: "$$nextSection.events",
                                            as: "event",
                                            in: {
                                                $cond: {
                                                    if: {
                                                        $in: [ "$$event.eventType", ["MISSION_FAILED_EVENT", "MISSION_ACCOMPLISHED_EVENT"] ]
                                                    },
                                                    then: true,
                                                    else: false
                                                }
                                            }
                                        }
                                    }/*,
                                    {
                                        $map: {
                                            input: "$$nextSection.events",
                                            as: "event",
                                            in: {
                                                $cond: {
                                                    if: {
                                                        $eq: [ "$$event.eventType", "MISSION_ACCOMPLISHED_EVENT" ]
                                                    },
                                                    then: true,
                                                    else: false
                                                }
                                            }
                                        }
                                    }*/
                                ]
                            }
                        ]
                    }
                }
            }
        }
    },
    {
        $group: {
            _id: "$region",
            terminateCount: {
                $sum: {
                    $cond: {
                        if: {
                            $and: [
                                {
                                    $ne: [ "$nextSections", [] ]
                                },
                                {
                                    $ne: [ "$nextSections", null ]
                                }
                            ]
                        },
                        then: 1,
                        else: 0
                    }
                }
            }
        }
    },
    {
        $group: {
            _id: null,
            maxTerminateCount: {
                $max: "$terminateCount"
            },
            regions: {
                $push: "$$CURRENT"
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
                        $eq: [ "$$region.terminateCount", "$maxTerminateCount" ]
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
        $project: {
            _id: 0,
            name: "$_id.name",
            sectionCount: "$terminateCount"
        }
    }
]);