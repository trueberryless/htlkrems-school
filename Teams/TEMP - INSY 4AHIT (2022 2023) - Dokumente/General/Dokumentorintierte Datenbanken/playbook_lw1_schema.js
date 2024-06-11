use playbooks;
//-- ------------------------------------------------------------------------------------ --
// --    Collection: personalities
// -- ----------------------------------------------------------------------------------- --
db.getCollection("lw1").drop();

db.createCollection(
   "lw1", {
        validationLevel  : "strict",
        validationAction : "error",
        validator : {
            $jsonSchema : {
                bsonType : "object",
                required : [
                   "sectionType", "content", "book"
                ],
                additionalProperties : true,
                properties : {
                    sectionType : {
                        enum : [
                            "RULE_SECTION",
                            "STORY_SECTION"
                        ]
                    },
                    content : {
                        bsonType : "string"
                    },
                    ruleType : {
                        enum : [
                            "TITLE_PAGE",
                            "THE_STORY_SO_FAR",
                            "ABILITIES",
                            "ITEMS",
                            "REGIONS"
                        ]
                    },
                    book : {
                        bsonType : "object",
                        required : [
                            "name", "imageUrl", "author", "illustrator"
                        ],
                        additionalProperties : false,
                        properties : {
                            name : {
                                bsonType : "string",
                                minLength : 1,
                                maxLength : 100
                            },
                            imageUrl : {
                                bsonType : "string",
                                minLength : 1,
                                maxLength : 100
                            },
                            author : {
                                bsonType : "string",
                                minLength : 1,
                                maxLength : 50
                            },
                            illustrator : {
                                bsonType : "string",
                                minLength : 1,
                                maxLength : 50
                            }
                        }
                    },
                    region : {
                        bsonType : "object",
                        required : [
                            "name",
                            "regionType",
                            "description",
                            "imageUrl"
                        ],
                        additionalProperties: true,
                        properties : {
                            name : {
                                bsonType : "string",
                                minLength : 1,
                                maxLength : 50
                            },
                            regionType : {
                                enum : [
                                    "BRIDGE",
                                    "BUILDING",
                                    "CAVE",
                                    "CITADEL",
                                    "CITY",
                                    "CITY_OUTSKIRTS",
                                    "CLEARING",
                                    "CONTINENT",
                                    "EVIL_TEMPLE",
                                    "GRAVEYARD",
                                    "KINGDOM",
                                    "LAKE",
                                    "PLACES_OF_WORSHIP",
                                    "MARSH",
                                    "RIVER_BANK",
                                    "RIVER_VALLEY",
                                    "ROAD",
                                    "STONE_BUILDING",
                                    "TEMPLE_RUIN",
                                    "VILLAGE",
                                    "WOOD_BUILDING",
                                    "WOODS"
                                ]
                            }
                        }
                    },
                    abilities : {
                        bsonType : "array",
                        items : {
                            bsonType : "object",
                            required : [
                                "abilityType", "description", "imageUrl"
                            ],
                            additionalProperties : false,
                            properties : {
                                abilityType : {
                                    enum : [
                                        "CAMOUFLAGE",
                                        "HUNTING",
                                        "SIXTH_SENSE",
                                        "TRACKING",
                                        "HEALING",
                                        "WEAPONSKILL",
                                        "MINDSHIELD",
                                        "MINDBLAST",
                                        "ANIMAL_KINSHIP",
                                        "MIND_OVER_MATTER"
                                    ]
                                },
                                 description: {
                                    bsonType : "string"
                                },
                                imageUrl : {
                                    bsonType : "string",
                                    minLength: 1,
                                    maxLength : 100
                                }
                            }
                        }
                    },
                    items : {
                        bsonType : "array",
                        items : {
                            bsonType : "object",
                            required : [
                                "code",
                                "name",
                                "itemType",
                                "description",
                                "weight",
                                "imageUrl"
                            ],
                            additionalProperties : false,
                            properties : {
                                code : {
                                    bsonType : "string",
                                    minLength : 2,
                                    maxLength : 20
                                },
                                name : {
                                    bsonType : "string",
                                    maxLength : 50
                                },
                                itemType : {
                                    enum : [
                                        "WEAPON",
                                        "MAGICAL_ITEM",
                                        "BACK_PACK",
                                        "KEY",
                                        "HERB",
                                        "GEM",
                                        "POTION",
                                        "SCROLL",
                                        "UTILITY"
                                    ]
                                },
                                description : {
                                    bsonType : "string"
                                },
                                weight : {
                                    enum : [
                                        "SMALL",
                                        "MEDIUM",
                                        "HEAVY"
                                    ]
                                },
                                imageUrl : {
                                    bsonType : "string"
                                }
                            }
                        }
                    },
                    sectionNr : {
                        bsonType : "int",
                        minimum : 1,
                        maximum : 500
                    },
                    events : {
                        bsonType : "array",
                        items : {
                            bsonType : "object",
                            required : [
                                "eventType", "ranking"
                            ],
                            additionalProperties : true,
                            properties : {
                                eventType : {
                                    enum : [
                                        "COMBAT",
                                        "ACQUIRE_ITEM_EVENT",
                                        "CHANGE_GOLD_AMOUNT_EVENT",
                                        "CHANGE_RATION_AMOUNT_EVENT",
                                        "MISSION_FAILED_EVENT",
                                        "TEMPORARY_CHANGE_COMBAT_SKILL_EVENT",
                                        "CHANGE_ENDURANCE_EVENT",
                                        "STORY_EVENT",
                                        "DROP_ALL_WEAPONS_EVENT",
                                        "DROP_BACKPACK_EVENT",
                                        "CHANGE_COMBAT_SKILL_EVENT",
                                        "DROP_ALL_ITEMS_EVENT",
                                        "DROP_WEAPON_EVENT",
                                        "MISSION_ACCOMPLISHED_EVENT"
                                    ]
                                },
                                ranking : {
                                    bsonType : "int",
                                    minimum : 1,
                                    maximum : 50
                                },
                                creature : {
                                    bsonType : "object",
                                    required : [
                                        "name",
                                        "combatSkill",
                                        "endurance",
                                        "imageUrl"
                                    ],
                                    additionalProperties : false,
                                    properties : {
                                        name : {
                                            bsonType : "string",
                                            minLength : 1,
                                            maxLength : 50
                                        },
                                        combatSkill : {
                                            bsonType : "int",
                                            minimum : 1,
                                            maximum : 200
                                        },
                                        endurance : {
                                            bsonType : "int",
                                            minimum : 1,
                                            maximum : 500
                                        },
                                        imageUrl : {
                                            bsonType : "string",
                                            maxLength : 100
                                        }
                                    }
                                },
                                item : {
                                    bsonType : "object",
                                    required : [
                                        "name",
                                        "itemType",
                                        "description",
                                        "weight",
                                        "imageUrl"
                                    ],
                                    additionalProperties : false,
                                    properties : {
                                        name : {
                                            bsonType : "string",
                                            maxLength : 50
                                        },
                                        itemType : {
                                            enum : [
                                                "WEAPON",
                                                "MAGICAL_ITEM",
                                                "BACK_PACK",
                                                "KEY",
                                                "HERB",
                                                "GEM",
                                                "POTION",
                                                "SCROLL",
                                                "UTILITY"
                                            ]
                                        },
                                        description : {
                                            bsonType : "string"
                                        },
                                        weight : {
                                            enum : [
                                                "SMALL",
                                                "MEDIUM",
                                                "HEAVY"
                                            ]
                                        },
                                        imageUrl : {
                                            bsonType : "string"
                                        }
                                    }
                                },
                                amount : {
                                    bsonType : "int"
                                }
                            }
                        }
                    },
                    outcomes : {
                        bsonType : "array",
                        items : {
                            bsonType : "object",
                            required : [
                                "outcomeType", "content", "targetNr"
                            ],
                            additionalProperties : true,
                            properties : {
                                outcomeType : {
                                    enum : [
                                        "DEFAULT",
                                        "RANDOM",
                                        "ABILITY",
                                        "ITEM",
                                        "GOLD",
                                        "MISSION_FAILED"
                                    ]
                                },
                                content : {
                                    bsonType : "string"
                                },
                                targetNr : {
                                    bsonType : "int",
                                    minimum : -1,
                                    maximum : 500
                                },
                                amount : {
                                    bsonType : "int"
                                },
                                ability : {
                                    bsonType : "object",
                                    required : [
                                        "abilityType", "description"
                                    ],
                                    additionalProperties : false,
                                    properties : {
                                        abilityType : {
                                             enum : [
                                                "CAMOUFLAGE",
                                                "HUNTING",
                                                "SIXTH_SENSE",
                                                "TRACKING",
                                                "HEALING",
                                                "WEAPONSKILL",
                                                "MINDSHIELD",
                                                "MINDBLAST",
                                                "ANIMAL_KINSHIP",
                                                "MIND_OVER_MATTER"
                                             ]
                                        },
                                        description : {
                                            bsonType : "string"
                                        }
                                    }
                                },
                                intervall : {
                                    bsonType : "object",
                                    required : [
                                        "min",
                                        "max"
                                    ],
                                    additionalProperties : false,
                                    properties : {
                                        min : {
                                            bsonType : "int",
                                            minimum : 0,
                                            maximum : 10
                                        },
                                        max : {
                                            bsonType : "int",
                                            minimum : 0,
                                            maximum : 10
                                        }
                                    }
                                },
                                item : {
                                    bsonType : "object",
                                    required : [
                                        "code",
                                        "name",
                                        "description",
                                        "imageUrl"
                                    ],
                                    additionalProperties : true,
                                    properties : {
                                        name : {
                                            bsonType : "string",
                                            minLength : 1,
                                            maxLength : 50
                                        },
                                        description : {
                                            bsonType : "string"
                                        },
                                        imageUrl : {
                                            bsonType : "string",
                                            minLength : 1,
                                            maxLength : 100
                                        },
                                        code : {
                                            bsonType : "string"
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
);


db.getCollection("lw1").insertMany([
    {
     /*
       * -- --------------------------------------------------------
       * --  Rulesection: Title Page
       * -- --------------------------------------------------------
       */
       sectionType : "RULE_SECTION",
       ruleType : "TITLE_PAGE",
       book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
       },
       content : "You are Lone Wolf. In a devastating attack the Darklords have destroyed the monastery where you were learning the skills of the Kai Lords. You are the sole survivor. In Flight from the Dark, you swear revenge. But first you must reach Holmgard to warn the King of the gathering evil. Relentlessly the servants of darkness hunt you across your country and every turn of the page presents a new challenge. Choose your skills and your weapons carefully—for they can help you succeed in the most fantastic and terrifying journey of your life."
    }, {
      /*
       * -- --------------------------------------------------------
       * --  Rulesection: The story so far
       * -- --------------------------------------------------------
       */
       sectionType : "RULE_SECTION",
       ruleType : "THE_STORY_SO_FAR",
       book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
       },
       content : "<p>In the northern land of Sommerlund, it has been the custom for many centuries to send the children of the Warrior Lords to the monastery of Kai. There they are taught the skills and disciplines of their noble fathers.The Kai monks are masters of their art, and the children in their charge love and respect them in spite of the hardships of their training. For one day when they have finally learnt the secret skills of the Kai, they will return to their homes equipped in mind and body to defend themselves against the constant threat of war from the Darklords of the west.</p> <p>In olden times, during the Age of the Black Moon, the Darklords waged war on Sommerlund. The conflict was a long and bitter trial of strength that ended in victory for the Sommlending at the great battle of Maakengorge. King Ulnar and the allies of Durenor broke the Darkland armies at the pass of Moytura and forced them back into the bottomless abyss of Maakengorge. Vashna, mightiest of the Darklords, was slain upon the sword of King Ulnar, called Sommerswerd, the sword of the sun. Since that age, the Darklords have vowed vengeance upon Sommerlund and the House of Ulnar.</p> <p>Now it is in the morning of the feast of Fehmarn, when all of the Kai Lords are present at the monastery for the celebrations. Suddenly a great black cloud comes from out of the western skies. So many are the numbers of the black-winged beasts that fill the sky, that the sun is completely hidden. The Darklords, ancient enemy of the Sommlending, are attacking. War has begun. On this fateful morning, you, Silent Wolf (the name given to you by the Kai) have been sent to collect firewood in the forest as a punishment for your inattention in class. As you are preparing to return, you see to your horror a vast cloud of black leathery creatures swoop down and engulf the monastery. Dropping the wood, you race to the battle that has already begun. But in the unnatural dark, you stumble and strike your head on a low tree branch. As you lose consciousness, the last thing that you see in the poor light is the walls of the monastery crashing to the ground.</p> <p>Many hours pass before you awake. With tears in your eyes you now survey the scene of destruction. Raising your face to the clear sky, you swear vengeance on the Darklords for the massacre of the Kai warriors, and with a sudden flash of realization you know what you must do. You must set off on a perilous journey to the capital city to warn the King of the terrible threat that now faces his people. For you are now the last of the Kai—you are now the Lone Wolf.</p>"
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Rulesection: Abilities
         * -- --------------------------------------------------------
         */
        sectionType : "RULE_SECTION",
        ruleType : "ABILITIES",
        book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
        },
        abilities : [
            {
                abilityType : "CAMOUFLAGE",
                description : "This Discipline enables a Kai Lord to blend in with his surroundings. In the countryside, he can hide undetected among trees and rocks and pass close to an enemy without being seen. In a town or city, it enables him look and sound like a native of that area, and can help him to find shelter or a safe hiding place.",
                imageUrl : "images/flight/abilities/camouflage.png"
            }, {
                abilityType : "HUNTING",
                description : "This skill ensures that a Kai Lord will never starve in the wild. He will always be able to hunt for food for himself except in areas of wasteland and desert. The skill also enables a Kai Lord to be able to move stealthily when stalking his prey.",
                imageUrl : "images/flight/abilities/hunting.png"
            }, {
                abilityType : "SIXTH_SENSE",
                description : "This skill enables a Kai Lord to make the correct choice of a path in the wild, to discover the location of a person or object in a town or city and to read the secrets of footprints or tracks.",
                imageUrl : "images/flight/abilities/sixthsense.png"
            }, {
                abilityType : "HEALING",
                description : "This Discipline can be used to restore ENDURANCE points lost in combat. If you possess this skill you may restore 1 ENDURANCE point to your total for every numbered section of the book you pass through in which you are involved in combat. (This is only to be used after your ENDURANCE has fallen below its original level.) Remember that your ENDURANCE cannot rise above its original level.",
                imageUrl : "images/flight/abilities/healing.png"
            }, {
                abilityType : "WEAPONSKILL",
                description : "Upon entering the Kai Monastery, each initiate is taught to master one type of weapon. If Weaponskill is to be one of your Kai Disciplines, pick a number in the usual way from the Random Number Table, and then find the corresponding weapon from the list below. This is the weapon in which you have skill. When you enter combat carrying this weapon, you add 2 points to your COMBAT SKILL.",
                imageUrl : "images/flight/abilities/weaponskill.png"
            }, {
                abilityType : "MINDSHIELD",
                description : "The Darklords and many of the evil creatures in their command have the ability to attack you using their Mindforce. The Kai Discipline of Mindshield prevents you from losing any ENDURANCE points when subjected to this form of attack.",
                imageUrl : "images/flight/abilities/mindshield.png"
            }, {
                abilityType : "MINDBLAST",
                description : "This enables a Kai Lord to attack an enemy using the force of his mind. It can be used at the same time as normal combat weapons and adds two extra points to your COMBAT SKILL. Not all the creatures encountered on this adventure will be harmed by Mindblast. You will be told if a creature is immune.",
                imageUrl : "images/flight/abilities/mindblast.png"
            }, {
                abilityType : "ANIMAL_KINSHIP",
                description : "This skill enables a Kai Lord to communicate with some animals and to be able to guess the intentions of others.",
                imageUrl : "images/flight/abilities/animalkinship.png"
            }, {
                abilityType : "MIND_OVER_MATTER",
                description : "Mastery of this Discipline enables a Kai Lord to move small objects with his powers of concentration.",
                imageUrl : "images/flight/abilities/mindovermatter.png"
            }
        ],
        content : "Over the centuries, the Kai monks have mastered the skills of the warrior. These skills are known as the Kai Disciplines, and they are taught to all Kai Lords. You have learnt only five of the skills listed below. The choice of which five skills these are, is for you to make. As all of the Disciplines may be of use to you at some point on your perilous quest, pick your five with care. The correct use of a Discipline at the right time can save your life."
    }, {
       /*
        * -- --------------------------------------------------------
        * --  Rulesection: Items
        * -- --------------------------------------------------------
        */
        sectionType : "RULE_SECTION",
        ruleType : "ITEMS",
        book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
        },
        items : [
            {
                code : "DAGGER",
                name : "Dagger",
                itemType : "WEAPON",
                description : "Dagger",
                weight : "SMALL",
                imageUrl : "images/flight/items/dagger.png"
            }, {
                code : "SPEAR",
                name : "Spear",
                itemType : "WEAPON",
                description : "Spear",
                weight : "MEDIUM",
                imageUrl : "images/flight/items/spear.png"
            }, {
                code : "MACE",
                name : "Mace",
                itemType : "WEAPON",
                description : "Mace",
                weight : "MEDIUM",
                imageUrl : "images/flight/items/mace.png"
            }, {
                code : "SHORT_SWORD",
                name : "Short Sword",
                itemType : "WEAPON",
                description : "Short Sord",
                weight : "MEDIUM",
                imageUrl : "images/flight/items/shortsword.png"
            }, {
                code : "WARHAMMER",
                name : "Warhammer",
                itemType : "WEAPON",
                description : "Warhammer",
                weight : "HEAVY",
                imageUrl : "images/flight/items/warhammer.png"
            }, {
                code : "SWORD",
                name : "Sword",
                itemType : "WEAPON",
                description : "Sword",
                weight : "MEDIUM",
                imageUrl : "images/flight/items/sword.png"
            }, {
                code : "AXE",
                name : "Axe",
                itemType : "WEAPON",
                description : "Axe",
                weight : "HEAVY",
                imageUrl : "images/flight/items/axe.png"
            }, {
                code : "QUARTER_STAFF",
                name : "Quarterstaff",
                itemType : "WEAPON",
                description : "Quarterstaff",
                weight : "SMALL",
                imageUrl : "images/flight/items/quarterstaff.png"
            }, {
                code : "BROADSWORD",
                name : "Broadsword",
                itemType : "WEAPON",
                description : "Broadsword",
                weight : "HEAVY",
                imageUrl : "images/flight/items/broadsword.png"
            }, {
                code : "VORDAK_GEM",
                name : "Vordak Gem",
                itemType : "WEAPON",
                description : "Vordak Gem",
                weight : "SMALL",
                imageUrl : "images/flight/items/vordakgem.png"
            }, {
                code : "BACK_PACK",
                name : "Back Pack",
                itemType : "WEAPON",
                description : "Back Pack",
                weight : "SMALL",
                imageUrl : "images/flight/items/backpack.png"
            }, {
                code : "GOLDEN_KEY",
                name : "Golden Key",
                itemType : "WEAPON",
                description : "Golden Key",
                weight : "SMALL",
                imageUrl : "images/flight/items/goldenkey.png"
            }
        ],
        content : "You are dressed in the green tunic and cloak of a Kai initiate. You have little with you to arm yourself for survival."
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Rulesection: Regions
         * -- --------------------------------------------------------
         */
         sectionType : "RULE_SECTION",
         ruleType : "REGIONS",
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         content : "... ",
         regionTree : {
                name : "Magnamund",
                regionType : "CONTINENT",
                description : "Originally Magnamund comprised one land mass. During the Age of Chaos, when Naar sought to destroy the wise dragon Nyxator, Magnamund was torn asunder, and the Tentarias strait split the land into the two continents of Northern Magnamund and Southern Magnamund. There are many notable geographic features on Magnamund. Features of other worlds and places can also be found here. The northwestern quarter of Northern Magnamund is the Darklands, a hellish wasteland ruled by the Darklords. It is in this terrible land that the Darklords create their armies and breed creatures of darkness. The northeastern quarter of Northern Magnamund is the Lastlands, giving rise to the human nations of Sommerlund and Durenor. It is against these bastions of hope that the full might of the Darklords is directed, for if Sommerlund and Durenor should fall, the rest of Magnamund would fall in their wake. The eastern third of Southern Magnamund is characterized by the Sadi desert and the Shadakine Empire. The tyrannical Shadakine Empire arose under the rulership of Shasarak the Wytch-king to conquer the free states of the south.",
                imageUrl : "images/flight/regions/magnamund.png",
                regions : [
                    {
                        name : "Sommerlund",
                        regionType : "KINGDOM",
                        description : "The country is situated on the Northern continent of Magnamund in the Northeastern corner. It is a sunlit land of verdant hills, deep forests and rich farmland. Its principal cities are Holmgard, Toran, Anskaven, Tyso, and Ruanon. It has been the Darklords bane since the time of King Kian.",
                        imageUrl : "images/flight/regions/sommerlund.png",
                        regions : [
                            {
                                name : "Kai Monastary",
                                regionType : "BUILDING",
                                description : "Kai Monastery is spiritual home and training ground of the Order of the Kai. The Tower of the Sun is the tallest tower in the Monastery. It contains the Lore Halls, the Kai Masters Hall and the Grandmasters Hall. The Kai Masters Hall is a chamber in the Tower of the Sun, positioned above the Lore Hall of the Spirit and below the Grandmasters Hall. It contains a plain, wooden throne and green pillars. The Grandmasters Hall is located in the topmost part of the Tower of the Sun. The order was founded in MS 3810 by a Baron of Sommerlund who later renamed himself Sun Eagle. He set out on a quest to find all the Lorestones of Nyxator and cultivate his inner talents, to the point where he became a Kai, with many superhuman abilities in fighting, his senses, and the ability to cure himself and others. He founded his monastery at the northwestern corner of Sommerlund near the Durcrag Mountains. During their long history, the First Order was renowned for their defense of Sommerlund, a vastly smaller country against the Darklords vaste hordes. During their time, it became almost a cyclical event of the Darklords attack and their repulsion from Sommerlund, thanks to the Kai. During Darklord Zagarnas war, the first order of the Kai was wiped out. And even after Lone Wolf successfully killed Archlord Zagarna and helped eject his armies from his country, he did not have time to attend to the creation of a new order. While Lone Wolf was sent to defeat the Deathlord of Ixia, other troubles were stirring far away in Sommerlund.",
                                imageUrl : "images/flight/regions/kaimonastary.png"
                            }, {
                                name : "Sommerlund Woodlands",
                                regionType : "WOODS",
                                description : "Deep Woods in Summerlund",
                                imageUrl : "images/flight/regions/sommerlundwoodlands.png",
                                regions : [
                                    {
                                        name : "River Valley",
                                        regionType : "RIVER_VALLEY",
                                        description : "River Valley",
                                        imageUrl : "images/flight/regions/sommerlundrivervalley.png"
                                    }, {
                                        name : "River Bridge",
                                        regionType : "BRIDGE",
                                        description : "Wooden bridge in the Summerlund Woodlands.",
                                        imageUrl : "images/flight/regions/woodenbridge.png"
                                    }, {
                                        name : "Graveyard of the Ancients",
                                        regionType : "GRAVEYARD",
                                        description : "The Graveyard of the Ancients is an ancient, mist-shrouded graveyard just North of Holmgard. This place is taboo because of the nameless horrors that inhabit it. No one knows who lies in eternal unrest here but the Evil that lives there is more ancient than the Darklords.",
                                        imageUrl : "images/flight/regions/graveyardofancients.png"
                                    }, {
                                        name : "Treehouse",
                                        regionType : "WOOD_BUILDING",
                                        description : "Looking up through the massive branches you can see a large treehouse some twhety-five feet above teh ground. There is no ladder, but the ganreld bark of teh tree offers many footholds.",
                                        imageUrl : "images/flight/regions/treehouse.png"
                                    }, {
                                        name : "Stoneclearing",
                                        regionType : "PLACES_OF_WORSHIP",
                                        description : "Your reach the top of a small wooded hill on which several large boulders form a rough circle.",
                                        imageUrl : "images/flight/regions/stoneclearing.png"
                                    }, {
                                        name : "Clearing",
                                        regionType : "CLEARING",
                                        description : "You pass through a long, dark tunnel of voerhanging branches that eventually opens out into a large clearing.",
                                        imageUrl : "images/flight/regions/clearing.png"
                                    }, {
                                        name : "Main Road",
                                        regionType : "ROAD",
                                        description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
                                        imageUrl : "images/flight/regions/sommerlundmainroad.png"
                                    }, {
                                        name : "Silvermoon Lake",
                                        regionType : "LAKE",
                                        description : "The Silvermoon Lake is a ...",
                                        imageUrl : "images/flight/regions/silvermoonlake.png"
                                    }, {
                                        name : "Village",
                                        regionType : "VILLAGE",
                                        description : "A small Village in the middle of the Summerlund Woodland.",
                                        imageUrl : "images/flight/regions/sommerlundvillage.png"
                                    }, {
                                        name : "Wafford Clearing",
                                        regionType : "CLEARING",
                                        description : "You soon reach a small clearing in the woods.",
                                        imageUrl : "images/flight/regions/waffordclearing.png"
                                    }, {
                                        name : "Cave",
                                        regionType : "CAVE",
                                        description : "The floor of the cave is quite dry and dusty. As you explore deeper in the half-light, you detect the stale odour of rotting flesh.",
                                        imageUrl : "images/flight/regions/cave.png"
                                    }, {
                                        name : "Old Watch Tower",
                                        regionType : "WOOD_BUILDING",
                                        description : "The old Watchtower is ...",
                                        imageUrl : "images/flight/regions/ruinwatchtower.png"
                                    }, {
                                        name : "Dragon Bridge",
                                        regionType : "BRIDGE",
                                        description : "The Dragon Bridge connects the northern and southern part of Summerlund.",
                                        imageUrl : "images/flight/regions/dragonbridge.png"
                                    }, {
                                        name : "Ruins of Raumas",
                                        regionType : "TEMPLE_RUIN",
                                        description : "Edging nearer, you soon make out a clearing that you recognize to be the site of the ruins of Raumas.",
                                        imageUrl : "images/flight/regions/runinsofraumas.png"
                                    }, {
                                        name : "Fogwood",
                                        regionType : "VILLAGE",
                                        description : "A little path through the wood leads to Gogwood, a small cluster of huts that have beein used by a family of charcoal burnder for nearly fifty years.",
                                        imageUrl : "images/flight/regions/fogwood.png"
                                    }, {
                                        name : "Darkstone Temple",
                                        regionType : "EVIL_TEMPLE",
                                        description : "It was only by an unlucky chance you discovered teh secret temple of a sect of evil druids",
                                        imageUrl : "images/flight/regions/darkstonetemple.png"
                                    }, {
                                        name : "Yellow Marsh",
                                        regionType : "MARSH",
                                        description : "You soon realize that you are walking deeper into a wooded marsh.",
                                        imageUrl : "images/flight/regions/yellowmarch.png"
                                    }
                                ]
                        }, {
                            name : "Holmgard",
                            regionType : "CITY",
                            description : "Holmgard is the capital of Sommerlund and is a seaport on the Holmgulf. It is located near the Graveyard of the Ancients. The city is enclosed by grey-white walls two hundred feet in height whose gatehouses are 100 yards long. At the center of the city is the Citadel of the King.",
                            imageUrl : "images/flight/regions/holmguard.png",
                            regions : [
                                {
                                    name : "Kings Citadel",
                                    regionType : "CITADEL",
                                    description : "The Kings Citadel is the highest law enforcement and paramilitary organization in Holmgard.",
                                    imageUrl : "images/flight/regions/holmguardcitadel.png"
                                }, {
                                    name : "Boat Crossing",
                                    regionType : "CITY_OUTSKIRTS",
                                    description : "The outer fildworks of the city can now be seen.",
                                    imageUrl : "images/flight/regions/holmguardoutskirts.png",
                                    regions : [
                                        {
                                            name : "Riverbank",
                                            regionType : "RIVER_BANK",
                                            description : "Peering over the steep undercut of the riverbank, you can see a tanble of driftwood along the waters edge.",
                                            imageUrl : "images/flight/regions/riverbank.png"
                                        }
                                    ]
                                }, {
                                    name : "Homgard Robbers Lane",
                                    regionType : "CITY",
                                    description : "The Homgard Robbers Lane is...",
                                    imageUrl : "images/flight/regions/holmguardupperlane.png"
                                }, {
                                    name : "Inner Courtyard",
                                    regionType : "STONE_BUILDING",
                                    description : "The inner courtyard is a bustle of activity. Cavalry scouts are waiting beside their nervous horses for messages from their unit commanders inside the  Great Hall. They  take orders with great speed to the defenders of the outer fieldworks.",
                                    imageUrl : "images/flight/regions/stonebuilding.png"
                                }, {
                                    name : "Holmgard - City Outscirts",
                                    regionType : "CITY_OUTSKIRTS",
                                    description : "You climb the wooded bank of the river and see the log walls of the fieldworks disappeiring into the distance. The log wall ahead of you has collapsed in several places.",
                                    imageUrl : "images/flight/regions/holmguardoutskirts.png"
                                }, {
                                    name : "Great Hall",
                                    regionType : "STONE_BUILDING",
                                    description : "The Great Hall is",
                                    imageUrl : "images/flight/regions/greathall.png"
                                }
                            ]
                        }
                    ]
                }
            ]
        }
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 1
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 1,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "As you dash through the thickening trees, the shouts of the Giaks begin to fade behind you. You have nearly outdistanced them completely, when you crash headlong into a tangle of low branches.",
         outcomes :  [
            {
                outcomeType : "ABILITY",
                targetNr : 141,
                ability : {
                    abilityType : "SIXTH_SENSE",
                    description : "This skill may warn a Kai Lord of imminent danger. It may also reveal the true purpose of a stranger or strange object encountered in your adventure."
                },
                content : "If you wish to use your Kai Discipline of Sixth Sense, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 88,
                content : "If you wish to take the right path into the wood, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 275,
                content : "If you wish to follow the left track, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 2
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 2,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "As you dash through the thickening trees, the shouts of the Giaks begin to fade behind you. You have nearly outdistanced them completely, when you crash headlong into a tangle of low branches.",
         outcomes :  [
            {
                outcomeType : "RANDOM",
                targetNr : 343,
                intervall : {
                    min : 0,
                    max : 4
                },
                content : "If you have picked a number 0–4, turn to "
            }, {
                outcomeType : "RANDOM",
                targetNr : 276,
                intervall : {
                    min : 5,
                    max : 9
                },
                content : "If you have picked a number 5-9, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 3
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 3,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Kings Citadel",
            regionType : "CITADEL",
            description : "The Kings Citadel is the highest law enforcement and paramilitary organization in Holmgard.",
            imageUrl : "images/flight/regions/holmguardcitadel.png"
         },
         content : "Staying close to the officer, you follow him through an arched portal and up a short flight of stairs to a long hall. Soldiers run back and forth bearing orders on ornate scrolls to officers stationed around the city wall. A haggard and scar-faced man dressed in the white and purple robes of the King’s court approaches you and bids you follow him to the citadel.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 196,
                content : "If you wish to follow this man, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 144,
                content : "If you wish to decline his offer and return to the crowded streets, turn to "
            }
         ]
    }
, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 4
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 4,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "River Valley",
            regionType : "RIVER_VALLEY",
            description : "River Valley",
            imageUrl : "images/flight/regions/sommerlundrivervalley.png"
         },
         content : "It is a small one-man canoe in very poor condition. The wood has split and warped, and the craft appears to be leaking in several places. You quickly patch up the worst of the holes with some clay and bail out the water. This seems to stop the leaking for the moment. Stowing your equipment at the bow, you set off downstream, using a piece of driftwood as a paddle. After a short while, you hear the sound of horses galloping towards you along the left bank.",
         outcomes :  [
            {
                outcomeType : "ABILITY",
                targetNr : 218,
                ability : {
                    abilityType : "SIXTH_SENSE",
                    description : "This skill may warn a Kai Lord of imminent danger. It may also reveal the true purpose of a stranger or strange object encountered in your adventure."
                },
                content : "If you wish to use the Kai Discipline of Sixth Sense, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 75,
                content : "If you wish to hide in the bottom of the canoe, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 175,
                content : "If you wish to try to attract their attention, turn to "
            }
         ]
    }
, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 5
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 5,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
          region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "After about an hour of walking, the track slowly bears round to the east. You reach a shallow ford where a fast-flowing brook runs on a steep rocky course towards the south. Just beyond the ford is a junction where the track meets a wider path running north to south. Realizing that the north path will take you away from the capital, you turn right at the junction and head south.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 11,
                content : "Turn to "
            }
         ]
    }
, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 6
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 6,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "In the distance you can hear the sound of horses galloping nearer. You crouch behind a tree and wait as the riders come closer. They are the cavalry of the King’s Guard wearing the white uniforms of His Majesty’s army.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 183,
                content : "If you wish to call them, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 200,
                content : "If you wish to let them pass and then continue on your way through the forest, turn to "
            }
         ]
    }
, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 7
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 7,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Holmgard",
            regionType : "CITY",
            description : "Holmgard is the capital of Sommerlund and is a seaport on the Holmgulf. It is located near the Graveyard of the Ancients. The city is enclosed by grey-white walls two hundred feet in height whose gatehouses are 100 yards long. At the center of the city is the Citadel of the King.",
            imageUrl : "images/flight/regions/holmguard.png"
         },
         content : "For what seems an eternity, the rush of the crowd carries you along like a leaf on a fast-flowing stream. You desperately fight to stay on your feet, but you feel weak and dizzy from your ordeal, and your legs are as heavy as lead. Suddenly, you catch a glimpse of a long, narrow stone stairway that leads up to the roof of an inn. Gathering the last reserves of your strength, you dive for the stairs and climb slowly up to the top. From here you can see the magnificent view of the rooftops and spires of Holmgard, with the high stone walls of the citadel gleaming in the sun. The houses and buildings of the capital are built very close to each other, and it is possible to jump from one roof to the next. In fact many of the citizens of Holmgard used to use the Roofways (as they are known) when the heavy autumn rains made the unpaved parts of the streets too muddy for walking. But after many accidents, a royal decree forbade their use. After careful thought, you decide to use the Roofways, as they are your only chance of reaching the King. You have hopped, skipped, and jumped across several streets and you are only one street away from the citadel when you come to the end of a row of rooftops. The jump to the next row is much further than anything you have tried before, and your stomach begins to feel as if it were full of butterflies. Determined to reach the citadel, you turn and take a long run-up to the jump. With blood pounding in your ears, you sprint to the edge of the roof and leap into space, your eyes fixed on the opposite rooftop. Pick a number from the Random Number Table.",
         outcomes :  [
           {
                outcomeType : "RANDOM",
                targetNr : 108,
                intervall : {
                    min : 0,
                    max : 2
                },
                content : "If you have picked a number that is 0–2, turn to "
            }, {
                outcomeType : "RANDOM",
                targetNr : 25,
                intervall : {
                    min : 3,
                    max : 9
                },
                content : "If the number is 3–9, turn to "
            }
         ]
    }
, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 8
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 8,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "River Bridge",
            regionType : "BRIDGE",
            description : "Wooden bridge in the Summerlund Woodlands.",
            imageUrl : "images/flight/regions/woodenbridge.png"
         },
         content : "Your Kai Sixth Sense warns there is a fierce battle raging in the south. Your common sense tells you that the south is also the quickest route to the capital.",
         outcomes :  [
           {
                outcomeType : "DEFAULT",
                targetNr : 70,
                content : "Turn to 70 and choose your route. "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 9
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 9,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Graveyard of the Ancients",
            regionType : "GRAVEYARD",
            description : "The Graveyard of the Ancients is an ancient, mist-shrouded graveyard just North of Holmgard. This place is taboo because of the nameless horrors that inhabit it. No one knows who lies in eternal unrest here but the Evil that lives there is more ancient than the Darklords.",
            imageUrl : "images/flight/regions/graveyardofancients.png"
         },
         content : "You cannot move: you are being held rigid by some powerful force. Your eyes are drawn towards the mouth of the skeleton. From deep in the earth you hear a low humming, like the sound of millions of angry bees. A dull red glow appears in the empty eye sockets of the dead King and the humming increases until your ears are filled with the deafening roar. You are in the presence of an ancient evil, far older and stronger than the Darklords themselves.",
         outcomes :  [
            {
                outcomeType : "ITEM",
                targetNr : 236,
                item : {
                    code : "VORDAK_GEM",
                    name : "Vordak Gem",
                    description : "Vordak Gem",
                    imageUrl : "images/flight/items/vordakgem.png"
                },
                content : "If you possess a Vordak Gem, turn to "
            },  {
                outcomeType : "DEFAULT",
                targetNr : 292,
                content : "If you do not, turn to "
            }
         ]
    } , {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 10
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 10,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "You are sweating and your legs ache. In the middle distance you can see a group of cottages.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 115,
                content : "If you wish to enter a cottage and rest for a while, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 83,
                content : "If you wish to press on, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 11
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 11,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Kings Citadel",
            regionType : "CITADEL",
            description : "The Kings Citadel is the highest law enforcement and paramilitary organization in Holmgard.",
            imageUrl : "images/flight/regions/holmguardcitadel.png"
         },
         content : "You quickly dodge into the doorway of a stable and hide your surgeon’s cloak in the straw, for it would be better to be seen as a Kai Lord than as a charlatan. Without wasting a second, you set off towards the Great Hall on the other side of the courtyard.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 139,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 12
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 12,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "The bodyguard looks at you with great suspicion and then slams the door shut. You can hear the sound of voices inside the caravan. Suddenly the door swings open and the face of a wealthy merchant appears. He demands 10 Gold Crowns as payment for the ride.",
         outcomes :  [
           {
                outcomeType : "GOLD",
                targetNr : 262,
                amount : -10,
                content : "If you have 10 Gold Crowns and wish to pay him, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 247,
                content : "If you do not have enough Gold Crowns or do not wish to pay him, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 13
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 13,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "The path soon ends at a large clearing. In the centre of the clearing is a tree much taller and wider than any other you have seen in the forest. Looking up through the massive branches you can see a large treehouse some twenty-five to thirty feet above the ground. There is no ladder, but the gnarled bark of the tree offers many footholds.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 307,
                content : "If you wish to climb the tree and search the treehouse, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 213,
                content : "If you would rather press on, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 14
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 14,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Stoneclearing",
            regionType : "PLACES_OF_WORSHIP",
            description : "Your reach the top of a small wooded hill on which several large boulders form a rough circle.",
            imageUrl : "images/flight/regions/stoneclearing.png"
         },
         content : "You reach the top of a small wooded hill on which several large boulders form a rough circle. Suddenly you hear a loud growl from behind a rock to your left.",
         outcomes :  [
           {
                outcomeType : "DEFAULT",
                targetNr : 43,
                content : "If you wish to draw your weapon and prepare to fight, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 106,
                content : "If you would rather take evasive action by running as fast as you can over the hill, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 15
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 15,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Clearing",
            regionType : "CLEARING",
            description : "You pass through a long, dark tunnel of voerhanging branches that eventually opens out into a large clearing.",
            imageUrl : "images/flight/regions/clearing.png"
         },
         content : "You pass through a long, dark tunnel of overhanging branche that eventually opens out into a large clearing. On a stone plinth in the centre of the clearing is a Sword, sheathed in a black leather scabbard. A handwritten note has been tied to the hilt, but it is in a language which is foreign to you. You may take the Sword if you wish, and note it on your Action Chart. There are three exits from the clearing.",
         outcomes :  [
           {
                outcomeType : "DEFAULT",
                targetNr : 207,
                content : "If you decide to go east, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 201,
                content : "If you decide to go west, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 35,
                content : "If you decide to go south, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 16
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 16,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "You manage to free a horse from the straps securing it to the caravan. It is frightened by the scent of the approaching Doomwolves, and the cries of their evil riders—the Giaks. Preparing your weapon, you spur your skittish horse towards the oncoming beasts. They are less than fifty yards away and they are lowering their lances at you as they get nearer and nearer.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 192,
                content : "You are charging head-on towards each other. Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 17
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 17,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "You raise your weapon to strike at the beast as its razor-fanged mouth snaps shut just inches from your head. Buffeted by the beating of its wings you find it difficult to stand. Deduct 1 point from your COMBAT SKILL and fight the Kraan. If you kill the creature, you quickly descend the far side of the hill to avoid the Giaks. Pick a number from the Random Number Table.",
         events : [
            {
                eventType : "COMBAT",
                ranking : 1,
                creature : {
                    name : "Kraan",
                    combatSkill : 16,
                    endurance : 24,
                    imageUrl : "images/flight/creatures/.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "RANDOM",
                targetNr : 53,
                intervall : {
                    min : 0,
                    max : 0
                },
                content : "If you pick 0, turn to "
            }, {
                outcomeType : "RANDOM",
                targetNr : 274,
                intervall : {
                    min : 1,
                    max : 2
                },
                content : "If you pick 1–2, turn to "
            }, {
                outcomeType : "RANDOM",
                targetNr : 316,
                intervall : {
                    min : 3,
                    max : 9
                },
                content : "If you pick 3–9, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 18
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 18,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Silvermoon Lake",
            regionType : "LAKE",
            description : "The Silvermoon Lake is a ...",
            imageUrl : "images/flight/regions/silvermoonlake.png"
         },
         content : "You are awoken by the sound of troops in the distance. Across the lake you see the black-cloaked figures of Drakkarim and a pack of Doomwolves and their riders. A Kraan appears from above the trees and lands on the roof of the small wooden shack. It is ridden by a creature dressed in red. The Kraan takes off and begins to fly across the lake to where you are hidden.",
         outcomes :  [
            {
                outcomeType : "ABILITY",
                targetNr : 114,
                ability : {
                    abilityType : "CAMOUFLAGE",
                    description : "This Discipline enables a Kai Lord to blend in with his surroundings. In the countryside, he can hide undetected among trees and rocks and pass close to an enemy without being seen. In a town or city, it enables him to look and sound like a native of that area, and can help him to find shelter or a safe hiding place."
                },
                content : "If you wish to use the Kai Discipline of Camouflage, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 239,
                content : "If you wish to ride deeper in the forest, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 29,
                content : "If you wish to fight the creature, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 19
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 19,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "Just ahead through the tall trees you can see clumps of dark-red gallowbrush, a thorny briar with sharp crimson barbs. The common name for this forest weed is Sleeptooth, for the thorns are very sharp and can make you feel weak and sleepy if they scratch your skin.",
         outcomes :  [
            {
                outcomeType : "ABILITY",
                targetNr : 69,
                ability : {
                    abilityType : "TRACKING",
                    description : "This skill enables a Kai Lord to make the correct choice of a path in the wild, to discover the location of a person or object in a town or city and to read the secrets of footprints or tracks."
                },
                content : "If you have the Kai Discipline of Tracking, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 272,
                content : "You can avoid the Sleeptooth by returning to the track. Turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 119,
                content : "Or you can push on through the briars, deeper into the forest, by turning to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 20
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 20,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Village",
            regionType : "VILLAGE",
            description : "A small Village in the middle of the Summerlund Woodland.",
            imageUrl : "images/flight/regions/sommerlundvillage.png"
         },
         content : "It seems that whoever lived here left in a great hurry—and they must have left quite recently. A half-eaten meal still remains on the table, and a mug of dark jala is still warm to the touch. Searching a chest and small wardrobe, you find a Backpack, food (enough for two Meals), and a Dagger. If you wish to take these items, remember to mark them on your Action Chart. You continue your mission.",
         events : [
            {
                eventType : "ACQUIRE_ITEM_EVENT",
                ranking : 1,
                item : {
                    name : "Dagger",
                    itemType : "WEAPON",
                    description : "A dagger is a small convinient weapon",
                    weight : "SMALL",
                    imageUrl : "images/flight/items/dagger.png"
                }
            },  {
                eventType : "ACQUIRE_ITEM_EVENT",
                ranking : 2,
                item : {
                    name : "Backpack",
                    itemType : "BACK_PACK",
                    description : "A backpack",
                    weight : "SMALL",
                    imageUrl : "images/flight/items/backpack.png"
                }
            }
         ],
         outcomes :  [
           {
                outcomeType : "DEFAULT",
                targetNr : 273,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 21
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 21,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "You have ridden about two miles into the tangle of trees when the ground becomes very marshy. Pick a number from the Random Number Table.",
         outcomes :  [
            {
                outcomeType : "RANDOM",
                targetNr : 189,
                intervall : {
                    min : 0,
                    max : 6
                },
                content : "If the number is 6 or below, you manage to steer clear of the morass and may now turn to "
            }, {
                outcomeType : "RANDOM",
                targetNr : 312,
                intervall : {
                    min : 7,
                    max : 8
                },
                content : "If the number is 7 or 8 you are stuck. The mud engulfs you up to your armpits. Your horse gives one last despairing scream as its muzzle disappears into the bubbling mud. "
            }, {
                outcomeType : "MISSION_FAILED",
                targetNr: -1,
                content : "the foul-smelling bog sucks you under and claims another victim. Your life and your mission end here."
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 22
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 22,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "Knocking aside the leader, you sprint off along the highway. Then behind you the ominous click of a crossbow being cocked sends a shiver down your spine. Pick a number from the Random Number Table.",
         outcomes :  [
            {
                outcomeType : "RANDOM",
                targetNr : 181,
                intervall : {
                    min : 0,
                    max : 4
                },
                content : "If you have picked a number 0–4, turn to "
            }, {
                outcomeType : "RANDOM",
                targetNr : 145,
                intervall : {
                    min : 5,
                    max : 9
                },
                content : "If you have picked a number 5–9, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 23
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 23,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Graveyard of the Ancients",
            regionType : "GRAVEYARD",
            description : "The Graveyard of the Ancients is an ancient, mist-shrouded graveyard just North of Holmgard. This place is taboo because of the nameless horrors that inhabit it. No one knows who lies in eternal unrest here but the Evil that lives there is more ancient than the Darklords.",
            imageUrl : "images/flight/regions/graveyardofancients.png"
         },
         content : "The corridor soon widens into a large hall. At the far end, a stone staircase leads up to a huge door. Two black candles on either side of the stone steps dimly illuminate the chamber. You notice that no wax has melted, and as you get nearer you can feel that they give off no heat. Ancient engravings cover the stone surfaces of the walls. Anxious to leave this evil tomb, you examine the door for a latch. An ornate pin appears to lock the door, but there is also a keyhole in the lockplate.",
         outcomes :  [
            {
                outcomeType : "ITEM",
                targetNr: 326,
                item : {
                    code : "GOLDEN_KEY",
                    name : "Golden Key",
                    description : "The Golden Key emmits a shimmer ..",
                    imageUrl : "images/flight/items/goldenkey.png"
                },
                content : "If you have a Golden Key and wish to use it, turn to "
            }, {
                outcomeType : "ABILITY",
                targetNr : 151,
                ability : {
                    abilityType : "MIND_OVER_MATTER",
                    description : "Mastery of this Discipline enables a Kai Lord to move small objects with his powers of concentration."
                },
                content : "If you have the Kai Discipline of Mind Over Matter, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 337,
                content : "If you wish to remove the pin, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 24
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 24,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "The merchant shouts to the driver of the caravan to jump. ‘We’re under attack!’ he cries, disappearing through a circular window.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 234,
                content : "If you decide to jump after him, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 184,
                content : "If you decide to run through the caravan and grab the reins of the horse team, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 25
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 25,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Homgard Robbers Lane",
            regionType : "CITY",
            description : "The Homgard Robbers Lane is...",
            imageUrl : "images/flight/regions/holmguardupperlane.png"
         },
         content : "You land with such a crash on the opposite roof, that the wind is knocked out of you and you lie flat on your back with your head in a spin. It takes a minute or so for you to realize that you’ve made it and are perfectly safe. When you are sure you are all right, you jump up and let out a shout for joy at your skill and daring. Quickly you find a way across the roof and climb down a long drainpipe to the street below. You see the large iron doors of the citadel open, and a wagon drawn by two large horses tries to leave. The horses are frightened by the noisy crowd and they both rear up, causing the wagon to smash a front wheel against the door. In the confusion, you see a chance to enter and quickly slip inside just as the guards slam the doors shut.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 139,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 26
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 26,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Graveyard of the Ancients",
            regionType : "GRAVEYARD",
            description : "The Graveyard of the Ancients is an ancient, mist-shrouded graveyard just North of Holmgard. This place is taboo because of the nameless horrors that inhabit it. No one knows who lies in eternal unrest here but the Evil that lives there is more ancient than the Darklords.",
            imageUrl : "images/flight/regions/graveyardofancients.png"
         },
         content : "Cautiously, you move along the corridor until you come to a sharp eastward turn. A strange greenish light can be seen in the distance.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 249,
                content : "If you wish to continue, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 100,
                content : "If you wish to go back and try the southern route, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 27
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 27,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "You walk along this path for over an hour, carefully watching the sky above you in case the Kraan attack again. Up ahead, a large tree has fallen across the path. As you approach you can hear voices coming from the other side of the massive trunk.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 250,
                content : "If you choose to attack, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 52,
                content : "If you choose to listen to what the voices say, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 28
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 28,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "After a few hundred yards, the path joins another one running north to south.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 130,
                content : "If you wish to go northwards, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 147,
                content : "If you wish to head south, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 29
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 29,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Silvermoon Lake",
            regionType : "LAKE",
            description : "The Silvermoon Lake is a ...",
            imageUrl : "images/flight/regions/silvermoonlake.png"
         },
         content : "You stride out to the water’s edge and prepare yourself for combat. The Kraan and its rider spot you and begin to speed across the lake barely inches above the surface. The rider lets out a scream that freezes your blood. He is a Vordak, a fierce lieutenant of the Darklords. He is upon you and you must fight him.",
         events : [
            {
                eventType : "COMBAT",
                ranking : 1,
                creature : {
                    name : "Vordak",
                    combatSkill : 18,
                    endurance : 25,
                    imageUrl : "images/flight/creatures/vordak.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 270,
                content : "If you win the fight, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 30
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 30,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "The people look tired and hungry. They have come many miles from their burning city. Suddenly, you hear the beat of huge wings coming from the north. ‘Kraan, Kraan! Hide yourselves!’ the cry goes up all along the road. Just in front of you, a wagon carrying small children breaks down, its right wheel jammed in a furrow. The children scream in panic.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 194,
                content : "If you wish to help the children, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 261,
                content : "If you’d rather run for the cover of the trees, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 31
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 31,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Dragon Bridge",
            regionType : "BRIDGE",
            description : "The Dragon Bridge connects the northern and southern part of Summerlund.",
            imageUrl : "images/flight/regions/dragonbridge.png"
         },
         content : "You try to comfort the injured man as best you can, but his wounds are serious and he is soon unconscious again. Covering him with his cape, you turn and press deeper into the forest.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 264,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 32
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 32,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "You have ridden about three miles when, in the distance, you spot the unmistakable silhouette of five large Doomwolves. Riding on their backs are Giaks. They seem to be going on ahead to where the path leads down into an open meadow. Suddenly, one of the Giaks leaves the others and begins to ride back along the path towards you.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 176,
                content : "If you wish to hide in the undergrowth and let him pass, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 340,
                content : "If you wish to fight him, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 33
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 33,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Clearing",
            regionType : "CLEARING",
            description : "You pass through a long, dark tunnel of voerhanging branches that eventually opens out into a large clearing.",
            imageUrl : "images/flight/regions/clearing.png"
         },
         content : "The floor of the cave is quite dry and dusty. As you explore deeper in the half-light, you detect the stale odour of rotting flesh. Littering a crevice are the bones, fur, and teeth of several small animals. You notice a small cloth bag among these remains which you open to discover 3 Gold Crowns. Pocketing these coins, you leave what appears to be the lair of a mountain cat and carefully descend the hill.",
         events : [
            {
                eventType : "CHANGE_GOLD_AMOUNT_EVENT",
                ranking : 1,
                amount : 3
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 248,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 34
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 34,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "Without warning, a terrible apparition in red robes swoops down from the sky on the back of a Kraan. Its cry freezes your blood. The beast is a Vordak, a fierce lieutenant of the Darklords. He is above you and you must fight him.",
         events : [
            {
                eventType : "COMBAT",
                ranking : 1,
                creature : {
                    name : "Vordak",
                    combatSkill : 18,
                    endurance : 25,
                    imageUrl : "images/flight/creatures/vordak.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 328,
                content : "If you win, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 35
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 35,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "The forest is becoming denser, and the path more tangled with thorny briars. Almost completely hidden by the undergrowth, you notice another path branching off towards the east. Your current route seems to be coming to a prickly end, so you decide to follow the new path eastwards.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 207,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 36
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 36,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Old Watch Tower",
            regionType : "WOOD_BUILDING",
            description : "The old Watchtower is ...",
            imageUrl : "images/flight/regions/ruinwatchtower.png"
         },
         content : "The old watchtower ladder is rotten and several rungs break as you climb. Pick a number from the Random Number Table.",
         outcomes :  [
            {
                outcomeType : "RANDOM",
                targetNr : 140,
                intervall : {
                    min : 0,
                    max : 4
                },
                content : "If the number is 4 or lower "
            }, {
                outcomeType : "RANDOM",
                targetNr : 323,
                intervall : {
                    min : 5,
                    max : 9
                },
                content : "If the number is 5 or higher "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 37
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 37,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Kings Citadel",
            regionType : "CITADEL",
            description : "The Kings Citadel is the highest law enforcement and paramilitary organization in Holmgard.",
            imageUrl : "images/flight/regions/holmguardcitadel.png"
         },
         content : "You are feeling tired and hungry and you must stop to eat. After your Meal, you retrace your steps back to the citadel and begin to walk around the high, indomitable stone wall. You discover another entrance on the eastern side, guarded as before by two armoured soldiers.",
         events : [
            {
                eventType : "CHANGE_RATION_AMOUNT_EVENT",
                ranking : 1,
                amount : -1
            }
         ],
         outcomes :  [
            {
                outcomeType : "ABILITY",
                targetNr : 282,
                ability : {
                    abilityType : "CAMOUFLAGE",
                    description : "This Discipline enables a Kai Lord to blend in with his surroundings. In the countryside, he can hide undetected among trees and rocks and pass close to an enemy without being seen. In a town or city, it enables him to look and sound like a native of that area, and can help him to find shelter or a safe hiding place."
                },
                content : "If you wish to use the Kai Discipline of Camouflage, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 289,
                content : "If you wish to approach them and tell your story, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 38
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 38,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "For half an hour or more you press on through the forest, through the rich vegetation and ferns. You happen upon a small clear stream where you stop for a few minutes to wash your face and drink of the cold, fresh water. Feeling revitalized, you cross the stream and press on. You soon notice the smell of wood smoke which seems to be drifting towards you from the north.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 128,
                content : "If you wish to investigate the smell of wood smoke, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 347,
                content : "If you would rather avoid the source of this smoke, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 39
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 39,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "After a few seconds, two small furry faces nervously appear over the top of the trunk. They say they are Kakarmi and tell you that the Kraan are everywhere. To the west lie the remains of their village but little is left of it now. They are trying to find the rest of their tribe who took to the forest when the ‘Black-wings’ attacked. They point behind them—east along the path—and tell you that the trail appears to be a dead end, but that if you continue through the undergrowth for a few yards more, you will find a watchtower where the path splits into three directions. Take the east path. This leads to the King’s highway between the capital city Holmgard and the northern port of Toran. You thank the Kakarmi, and bid them farewell.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 228,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 40
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 40,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "Keeping a careful watch on the huts for any sign of the enemy, you make your way around the clearing under the cover of the trees and bracken. Rejoining the track, you hurry away from Fogwood.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 105,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 41
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 41,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Silvermoon Lake",
            regionType : "LAKE",
            description : "The Silvermoon Lake is a ...",
            imageUrl : "images/flight/regions/silvermoonlake.png"
         },
         content : "Three rangers gallop past the river bank, closely followed by the Giaks on their snarling Doomwolves. The bank is steep and you are spotted by the Giak leader who orders five of his troops to open fire at you with their bows. Their black arrows rain down on you.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 174,
                content : "If you decide to paddle downstream as fast as you can, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 116,
                content : "If you decide to head for the cover of the trees on the opposite bank, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 42
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 42,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "You follow the track for nearly an hour when you come to a crossroads.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 86,
                content : "If you wish to continue east, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 238,
                content : "If you would rather head north, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 157,
                content : "If you decide to venture south, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 147,
                content : "Or if you prefer to go west, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 43
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 43,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "From behind the rock a huge black bear comes into view. It advances slowly towards you, its mouth open and its face lined in anger and pain. You notice that it is badly wounded and is bleeding from its neck and back. You must fight it.",
         events : [
            {
                eventType : "COMBAT",
                ranking : 1,
                creature : {
                    name : "Black Bear",
                    combatSkill : 16,
                    endurance : 10,
                    imageUrl : "images/flight/creatures/.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 195,
                content : "If you win, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 44
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 44,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "Without warning, the old track ends abruptly at the edge of a steep slope. The ground here is very loose and unstable. You lose your footing and fall headlong over the edge. Pick a number from the Random Number Table.",
         outcomes :  [
            {
                outcomeType : "RANDOM",
                targetNr : 277,
                intervall : {
                    min : 0,
                    max : 4
                },
                content : "If you have picked a number that is 0–4, turn to "
            }, {
                outcomeType : "RANDOM",
                targetNr : 338,
                intervall : {
                    min : 5,
                    max : 9
                },
                content : "If the number is 5–9, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 45
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 45,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Boat Crossing",
            regionType : "CITY_OUTSKIRTS",
            description : "The outer fildworks of the city can now be seen.",
            imageUrl : "images/flight/regions/holmguardoutskirts.png",
         },
         content : "These men are not what they seem. The tunic of the leader is genuine but it is heavily bloodstained around the collar, as if its true owner had been murdered. Their weapons are not army issue, but expensive and lavishly decorated like the weapons made by the armourers of Durenor. The leader has a crossbow slung over his pack. An attempt to run would be suicide. You decide that you must fight them or you will surely be murdered as soon as you drop your weapon.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 178,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 46
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 46,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Silvermoon Lake",
            regionType : "LAKE",
            description : "The Silvermoon Lake is a ...",
            imageUrl : "images/flight/regions/silvermoonlake.png"
         },
         content : "You have covered about two miles when the trees ahead thin out. You can see a small wooden shack on the edge of a lake. A cloaked man approaches you and offers to row you and your horse across the lake for a fee of 2 Gold Crowns.",
         outcomes :  [
            {
                outcomeType : "ABILITY",
                targetNr : 296,
                ability : {
                    abilityType : "SIXTH_SENSE",
                    description : "This skill may warn a Kai Lord of imminent danger. It may also reveal the true purpose of a stranger or strange object encountered in your adventure."
                },
                content : "If you have the Kai Discipline of Sixth Sense, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 246,
                content : "If you accept the offer, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 90,
                content : "If you refuse and try to ride around the lake, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 47
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 47,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "Breathless and sweating, you claw your way towards the summit of the hill. Suddenly, a large winged shadow passes across the hillside. You look up to see a Kraan circling the peak above. Behind you the Giaks are gaining ground.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 136,
                content : "Do you stand and fight the Giaks where you are, using the high ground to your advantage? If so, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 322,
                content : "Or do you grit your teeth and press on towards the peak of the hill? Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 48
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 48,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "Your Sixth Sense warns you that these troops are not all they seem. You can detect an aura of evil about them. They are in the service of the Darklords.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 243,
                content : "You must leave here quickly before you are spotted. Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 49
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 49,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Holmgard",
            regionType : "CITY",
            description : "Holmgard is the capital of Sommerlund and is a seaport on the Holmgulf. It is located near the Graveyard of the Ancients. The city is enclosed by grey-white walls two hundred feet in height whose gatehouses are 100 yards long. At the center of the city is the Citadel of the King.",
            imageUrl : "images/flight/regions/holmguard.png"
         },
         content : "As you begin to read the inscription, you notice a shadow moving towards you from behind the screen. Pick a number from the Random Number Table.",
         outcomes :  [
           {
                outcomeType : "RANDOM",
                targetNr : 339,
                intervall : {
                    min : 0,
                    max : 4
                },
                content : "If you have chosen a number that is 0–4, turn to "
            }, {
                outcomeType : "RANDOM",
                targetNr : 60,
                intervall : {
                    min : 5,
                    max : 9
                },
                content : "If the number is 5–9, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 50
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 50,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Dragon Bridge",
            regionType : "BRIDGE",
            description : "The Dragon Bridge connects the northern and southern part of Summerlund.",
            imageUrl : "images/flight/regions/dragonbridge.png"
         },
         content : "The sound of fighting can be heard in the distance.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 97,
                content : "If you wish to continue towards the sound of battle, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 243,
                content : "If you wish to avoid the fighting, change direction and turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 51
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 51,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Boat Crossing",
            regionType : "CITY_OUTSKIRTS",
            description : "The outer fildworks of the city can now be seen.",
            imageUrl : "images/flight/regions/holmguardoutskirts.png"
         },
         content : "You climb the wooded bank of the river and see the log walls of the fieldworks disappearing into the distance. A battle rages about two miles away and the log wall has collapsed in several places where the Darklords are attacking. Most of the fieldworks ahead are unmanned, the soldiers having left to supply reinforcements for the raging battle.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 288,
                content : "There is a gate in the log wall. If you wish to approach it, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 221,
                content : "If you would prefer to climb over the wall instead, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 52
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 52,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "Now that you are closer, you can make out that the voices are not human. The sound is more like a kind of grunting and squeaking.",
         outcomes :  [
            {
                outcomeType : "ABILITY",
                targetNr : 225,
                ability : {
                    abilityType : "ANIMAL_KINSHIP",
                    description : "This skill enables a Kai Lord to communicate with some animals and to be able to guess the intentions of others."
                },
                content : "If you have the Kai Discipline of Animal Kinship, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 250,
                content : "If not, you must climb over the tree and face whatever lurks on the other side. Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 53
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 53,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "A searing pain tears through your right leg as it is twisted and crushed by the weight of your body. Down and down you tumble, until you finally land in a ditch at the base of the hill with such force that the wind is knocked out of you and you lose consciousness. You are awoken by the sharp pain of something stabbing your chest. It proves to be the tip of a Giak spear. You are greeted by the malicious sneer of its owner as he pins your left arm to the ground. Instinctively you reach for your weapon but it is no longer there. Defenceless against the cruel Giaks, the last thing that you see before all light fades is the jagged point of a Giak lance hurtling down towards your throat. Your mission ends here.",
         events : [
            {
                eventType : "MISSION_FAILED_EVENT",
                ranking : 1
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 54
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 54,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "It would seem that the heavens have not heard your prayers. A spear whistles past your head and embeds itself in the neck of your galloping horse. With a shriek of pain, the horse topples forward and you both roll in a tangled heap on the highway. Dazed and pinned down by the weight of the dead body of your horse, the last thing you remember is the sharp penetrating spearheads of the Giak lances. You have failed in your mission.",
         events : [
            {
                eventType : "MISSION_FAILED_EVENT",
                ranking : 1
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 55
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 55,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Ruins of Raumas",
            regionType : "TEMPLE_RUIN",
            description : "Edging nearer, you soon make out a clearing that you recognize to be the site of the ruins of Raumas.",
            imageUrl : "images/flight/regions/runinsofraumas.png"
         },
         content : "Just as the Giak makes his leap, you race forward and strike out with your weapon—knocking the creature away from the young wizard’s back. You jump onto the struggling Giak and strike again. Due to the surprise of your attack, add 4 points to your COMBAT SKILL for the duration of this fight but remember to deduct it again as soon as the fight is over.",
         events : [
            {
                eventType : "COMBAT",
                ranking : 2,
                creature : {
                    name : "Giak",
                    combatSkill : 9,
                    endurance : 9,
                    imageUrl : "images/flight/creatures/giak.png"
                }
            }, {
                eventType : "TEMPORARY_CHANGE_COMBAT_SKILL_EVENT",
                ranking : 1,
                amount : 4
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 325,
                content : "If you win, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 56
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 56,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "You hear the scream of a large winged beast above the trees. It is a Kraan, a deadly servant of the Darklords. Quickly you hide beneath the thick fronds of fern until the horrible shrieks have passed away.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 222,
                content : "Now turn to "
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 57
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 57,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "The cabin has only one room. In it you see a wooden table and two benches, a large bed made of straw bales lashed together, several bottles of coloured liquids, and an embroidered rug in the centre of the floor.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 164,
                content : "If you choose to take a closer look at the bottles, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 109,
                content : "If you choose to pull back the rug, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 308,
                content : "If you choose to leave the room and investigate the stable, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 58
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 58,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Boat Crossing",
            regionType : "CITY_OUTSKIRTS",
            description : "The outer fildworks of the city can now be seen.",
            imageUrl : "images/flight/regions/holmguardoutskirts.png"
         },
         content : "Bracing yourself for the run, you head off down the ridge at a steady pace. To the west, the army of the Darklords looks like a giant pot of black ink that has been spilled between the mountains and is spreading into the land below. You have been running for twenty minutes when you catch sight of a pack of Doomwolves lining a shallow ridge to your right.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 251,
                content : "If you decide to flatten yourself against the rocks along the side of the road and wait until they pass, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 160,
                content : "If you decide to carry on running, but draw your weapon just in case they attack, turn to "
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 59
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 59,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Clearing",
            regionType : "CLEARING",
            description : "You pass through a long, dark tunnel of voerhanging branches that eventually opens out into a large clearing.",
            imageUrl : "images/flight/regions/clearing.png"
         },
         content : "Peering into the darkness, you notice that rough stairs have been cut into the earth and that the mouth of the cave is in fact the entrance to a tunnel. Carefully descending the slippery stairway, you notice a small silver box on a shelf at the bottom of the staircase.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 124,
                content : "If you want to open the silver box, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 106,
                content : "If you wish to return to the surface and press on, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 211,
                content : "If you wish to investigate the tunnel further, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 60
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 60,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Holmgard",
            regionType : "CITY",
            description : "Holmgard is the capital of Sommerlund and is a seaport on the Holmgulf. It is located near the Graveyard of the Ancients. The city is enclosed by grey-white walls two hundred feet in height whose gatehouses are 100 yards long. At the center of the city is the Citadel of the King.",
            imageUrl : "images/flight/regions/holmguard.png"
         },
         content : "The last thing you remember before darkness engulfs you is the flash of a long curved steel knife. You have become yet another victim of the Sage and his robber son—the very one who has just slit your throat! Your quest ends here.",
         events : [
            {
                eventType : "MISSION_FAILED_EVENT",
                ranking : 1
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 61
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 61,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Boat Crossing",
            regionType : "CITY_OUTSKIRTS",
            description : "The outer fildworks of the city can now be seen.",
            imageUrl : "images/flight/regions/holmguardoutskirts.png"
         },
         content : "At last you can reach the wooden fieldworks surrounding the outer city. As you race towards a sentry post, you can hear the excited shouts of the guards cheering you on. Thank the gods that they recognize you, for you must appear a ragged and suspicious figure. Your cloak is torn and hangs in tatters, your face is scratched and blood-smeared, and the dust of the Graveyard covers you from head to toe. Splashing through a shallow stream, you stagger towards the gate. The full horror of the Graveyard encounter begins to catch up with you. The last thing you recall before exhaustion robs you of consciousness, is falling into the outstretched arms of two soldiers who have run from the fieldworks to help you.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 268,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 62
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 62,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Boat Crossing",
            regionType : "CITY_OUTSKIRTS",
            description : "The outer fildworks of the city can now be seen.",
            imageUrl : "images/flight/regions/holmguardoutskirts.png"
         },
         content : "The ‘soldiers’ lie dead at your feet. They were bandits who were stealing from the refugees of Toran, and from the abandoned houses and farms in the area. Searching their bodies you find 28 Gold Crowns and two Backpacks containing enough food for 3 Meals. They had been armed with a crossbow and three Swords. The crossbow has been damaged in the fight, but the Swords are untouched and you may keep one if you wish. You adjust your equipment, give a cautious glance towards the west, and continue your run towards the outer defences of the capital.",
         events : [
            {
                eventType : "ACQUIRE_ITEM_EVENT",
                ranking : 1,
                item : {
                    name : "Crossbow",
                    itemType : "WEAPON",
                    description : "Crossbow",
                    weight : "MEDIUM",
                    imageUrl : "images/flight/items/.png"
                }
            }, {
                eventType : "ACQUIRE_ITEM_EVENT",
                ranking : 2,
                item : {
                    name : "Sword",
                    itemType : "WEAPON",
                    description : "Sword",
                    weight : "MEDIUM",
                    imageUrl : "images/flight/items/.png"
                }
            }, {
                eventType : "CHANGE_GOLD_AMOUNT_EVENT",
                ranking : 3,
                amount : 28
            }, {
                eventType : "CHANGE_RATION_AMOUNT_EVENT",
                ranking : 4,
                amount : 3
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 288,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 63
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 63,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Holmgard",
            regionType : "CITY",
            description : "Holmgard is the capital of Sommerlund and is a seaport on the Holmgulf. It is located near the Graveyard of the Ancients. The city is enclosed by grey-white walls two hundred feet in height whose gatehouses are 100 yards long. At the center of the city is the Citadel of the King.",
            imageUrl : "images/flight/regions/holmguard.png"
         },
         content : "The wild old man is screaming at you. He blames you for the war and curses the Kai Lords as agents of the Darklords. He will not listen to reason and you must fight him.",
         events : [
            {
                eventType : "COMBAT",
                ranking : 1,
                creature : {
                    name : "Madman",
                    combatSkill : 11,
                    endurance : 10,
                    imageUrl : "images/flight/creatures/madman.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 269,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 64
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 64,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "You are awoken by the cries of a Kraan circling above the caravan. It is early morning and the sky is clear and bright. You can see a pack of Doomwolves less than a quarter of a mile away along the highway ahead. They are preparing to attack. You must act quickly.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 188,
                content : "If you decide to gather your equipment and run for the cover of the trees, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 16,
                content : "If you decide to cut free one of the horses and try to break through the attacking Doomwolves to the clear road beyond, then turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 65
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 65,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Graveyard of the Ancients",
            regionType : "GRAVEYARD",
            description : "The Graveyard of the Ancients is an ancient, mist-shrouded graveyard just North of Holmgard. This place is taboo because of the nameless horrors that inhabit it. No one knows who lies in eternal unrest here but the Evil that lives there is more ancient than the Darklords.",
            imageUrl : "images/flight/regions/graveyardofancients.png"
         },
         content : "Your senses scream at you that this place is very evil. Leave as quickly as you can.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 104,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 66
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 66,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Great Hall",
            regionType : "STONE_BUILDING",
            description : "The Great Hall is",
            imageUrl : "images/flight/regions/greathall.png"
         },
         content : "Startled, you turn around to see a burly sergeant and two soldiers running towards you, their swords drawn as if to strike. You prepare to defend yourself for it looks as if they are about to attack first and ask questions later; but suddenly the sergeant calls his men to a halt. He has recognized your cloak. They put away their weapons and apologize many times for their mistake. The sergeant orders one of the men to fetch the captain of the Guard as he leads you to the doors of the Great Hall. You are greeted by a tall and handsome warrior who listens intently to your story. When you have finished the account of your perilous journey to the capital, you notice a tear in the brave man’s eye as he bids you to follow him. You walk through the splendid halls and corridors of the inner Palace. The richness and grandeur are a wonder to behold. You eventually arrive at a large carved door, guarded by two soldiers wearing silver armour. You are about to meet the King.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 350,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 67
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 67,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "Your Kai Discipline of Tracking reveals to you fresh paw prints leading off along the south path. They are the prints of a black bear, an animal renowned for its ferocity. You decide the east path would be a much safer route.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 252,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 68
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 68,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "After a short walk, you reach a junction where a path crosses your present route heading from west to east.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 130,
                content : "If you wish to turn west, go to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 15,
                content : "If you wish to head east, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 69
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 69,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "You are very near a friendly village. ",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 272,
                content : "Avoid the gallowbrush and turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 70
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 70,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "River Bridge",
            regionType : "BRIDGE",
            description : "Wooden bridge in the Summerlund Woodlands.",
            imageUrl : "images/flight/regions/woodenbridge.png"
         },
         content : "You have reached a small bridge. A track follows the stream towards the east. A much narrower path disappears into thick forest towards the south.",
         outcomes :  [
            {
                outcomeType : "ABILITY",
                targetNr : 8,
                ability : {
                    abilityType : "SIXTH_SENSE",
                    description : "This skill may warn a Kai Lord of imminent danger. It may also reveal the true purpose of a stranger or strange object encountered in your adventure."
                },
                content : "If you wish to use the Kai Discipline of Sixth Sense, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 28,
                content : "If you wish to go east, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 157,
                content : "If you wish to go south, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 71
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 71,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Graveyard of the Ancients",
            regionType : "GRAVEYARD",
            description : "The Graveyard of the Ancients is an ancient, mist-shrouded graveyard just North of Holmgard. This place is taboo because of the nameless horrors that inhabit it. No one knows who lies in eternal unrest here but the Evil that lives there is more ancient than the Darklords.",
            imageUrl : "images/flight/regions/graveyardofancients.png"
         },
         content : "You are winded but not hurt. You have fallen fifteen feet or so through the roof of an underground tomb. The walls are sheer and you cannot climb them. An arched tunnel leads out of the tomb towards the east, in front of which lies the sarcophagus of some ancient noble.",
         outcomes :  [
            {
                outcomeType : "ABILITY",
                targetNr : 65,
                ability : {
                    abilityType : "SIXTH_SENSE",
                    description : "This skill may warn a Kai Lord of imminent danger. It may also reveal the true purpose of a stranger or strange object encountered in your adventure."
                },
                content : "If you wish to use the Kai Discipline of Sixth Sense, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 242,
                content : "If you wish to open the sarcophagus to see if it contains any treasure, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 104,
                content : "If you wish to leave via the tunnel, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 72
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 72,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "You turn to face a sneering Giak and the razor-fanged jaws of its mount. You must fight them as one enemy.",
         events : [
            {
                eventType : "COMBAT",
                ranking : 1,
                creature : {
                    name : "Giak on Doomwolf",
                    combatSkill : 15,
                    endurance : 24,
                    imageUrl : "images/flight/creatures/.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 265,
                content : "If you win, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 73
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 73,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "Pulling your green cloak about you, you blend into the foliage and rocks. Peering carefully up at the track, you are shocked to see that they are not the King’s men at all. They are Drakkarim, some of the Darklords’ cruellest troops. They must have disguised themselves as soldiers of the King in order to get this far into the forest. Thanking your Kai training for saving your life, you silently slip away from the stream and push on into the forest.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 243,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 74
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 74,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "The Kraan and its riders land on the track barely ten feet from where you are hidden. The Giaks leap from the scaly backs of the Kraan and move towards you, their spears raised to strike. You have been seen.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 141,
                content : "If you decide to fight them, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 281,
                content : "If you decide to run deeper into the forest without delay, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 75
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 75,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "Peering out carefully, you can see three green-clad men on horses racing along the bank. You recognize them as Border Rangers, the regiment of the King’s Army that police the western borders. One of them is wounded and is slumped over the neck of his horse. Close behind follow a pack of twenty Doomwolves. Their Giak riders are firing arrows at the rangers which fall all around them. One ranger drops from his horse and rolls down the river bank, a black arrow deeply embedded in his right leg.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 260,
                content : "If you wish to help the ranger, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 163,
                content : "If you wish to stay hidden and drift downstream, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 76
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 76,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Boat Crossing",
            regionType : "CITY_OUTSKIRTS",
            description : "The outer fildworks of the city can now be seen.",
            imageUrl : "images/flight/regions/holmguardoutskirts.png"
         },
         content : "The Gem feels very hot and burns your hand. Lose 2 ENDURANCE points. You quickly grab it with the edge of your cloak and slip this Vordak Gem into your Backpack. A Gem that size must be worth hundreds of Crowns. You smile at your good fortune, mount your horse, and ride off along the south track.",
         events : [
              {
                eventType : "CHANGE_ENDURANCE_EVENT",
                ranking : 1,
                amount : -2
             }, {
                eventType : "ACQUIRE_ITEM_EVENT",
                ranking : 2,
                item : {
                    name : "Glowing Gem",
                    itemType : "MAGICAL_ITEM",
                    description : "Glowing Gem",
                    weight : "SMALL",
                    imageUrl : "images/flight/items/glowinggem.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 118,
                content : "Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 77
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 77,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "The Mountain Giaks are unaccustomed to pursuing their prey through forests and you soon outdistance them, until finally the sound of their grunts and curses disappears completely. When you are satisfied that they have given up the chase, you stop for a few minutes to catch your breath and check your equipment. With the memory of your ruined monastery still blazing in your mind, you gather up your meagre belongings and push on.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 19,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 78
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 78,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "As the caravan careers past, you leap for the tailboard and manage to hold fast. Pulling yourself upright, you find that you are standing on the bottom rung of a ladder leadingto the rear door of the wagon. Suddenly the top half of the door flies open and you are confronted by the angry face of a bodyguard.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 132,
                content : "If you decide to inform him that you are a Kai Lord with an urgent message for the King, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 12,
                content : "If you decide to offer him Gold Crowns for safe passage to the capital, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 220,
                content : "If you decide to attack the guard with your weapon, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 79
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 79,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "You come to a small footbridge across a fast-flowing stream. On the other side of the bridge the path turns south. You cross the bridge and follow the path.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 204,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 80
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 80,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Holmgard",
            regionType : "CITY",
            description : "Holmgard is the capital of Sommerlund and is a seaport on the Holmgulf. It is located near the Graveyard of the Ancients. The city is enclosed by grey-white walls two hundred feet in height whose gatehouses are 100 yards long. At the center of the city is the Citadel of the King.",
            imageUrl : "images/flight/regions/holmguard.png"
         },
         content : "You stumble backwards through the front door, clutching your burnt chest with both hands. Smoke is billowing from the shop and you must run—before the Sage or his robber son catch you. You make it back to the main street and lose yourself in the rush of the crowds.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 7,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 81
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 81,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "After nearly an hour, the Kraan and their cruel riders vanish towards the west. As the shocked refugees start to emerge from the woods, you can hear the sound of horses in the distance galloping nearer. You stay hidden and wait as the riders come closer. They are the cavalry of the King’s Guard wearing the white uniforms of His Majesty’s army.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 183,
                content : "If you wish to call to them, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 200,
                content : "If you would rather continue along the forest edge towards the south, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 82
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 82,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Dragon Bridge",
            regionType : "BRIDGE",
            description : "The Dragon Bridge connects the northern and southern part of Summerlund.",
            imageUrl : "images/flight/regions/dragonbridge.png"
         },
         content : "The giant Gourgaz lies dead at your feet. His evil followers hiss at you and then fall back from the bridge. The Prince’s soldiers form a protective wall around you and their dying leader with their shields. Black arrows whistle past your head.The dying Prince looks up into your eyes and says, ‘Kai Lord, you must take a message to my father. The enemy is too strong, we cannot hold him. The King must seek that which is in Durenor or all is lost. Take my horse and ride for the capital. May the luck of the gods ride with you.’You bid a sad farewell to the Prince, mount his white steed, and head south along the forest path. The battle still rages behind you as the Prince’s men fight off another assault on the bridge.",
         events : [
            {
                eventType : "STORY_EVENT",
                ranking : 1,
                code : "THE_DYING_PRINCE"
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 235,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 83
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 83,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Boat Crossing",
            regionType : "CITY_OUTSKIRTS",
            description : "The outer fildworks of the city can now be seen.",
            imageUrl : "images/flight/regions/holmguardoutskirts.png"
         },
         content : "You have run about a mile when three soldiers appear from beneath a small footbridge. They demand that you halt and drop your weapons and equipment. They are bloodstained and unshaven. Their leader is wearing the tunic of a soldier of the Toran garrison.",
         outcomes :  [
            {
                outcomeType : "ABILITY",
                targetNr : 45,
                ability : {
                    abilityType : "SIXTH_SENSE",
                    description : "This skill may warn a Kai Lord of imminent danger. It may also reveal the true purpose of a stranger or strange object encountered in your adventure."
                },
                content : "If you possess the Kai Discipline of Sixth Sense, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 205,
                content : "If you wish to do as they say, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 180,
                content : "If you wish to prepare to fight them, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 232,
                content : "If you demand to know what they want, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 84
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 84,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "Just as you feel the air beating on your back, you slip free of your horse and roll over—landing with a splash in a muddy ditch by the side of the highway. You are uninjured, and you quickly scramble to your feet and make a dash for the cover of the trees—but with thirty yards left to run, you see the Kraan circling above for another dive.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 188,
                content : "Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 85
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 85,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "he path is wide and leads straight into thick undergrowth. The trees are tall here and unusually quiet. You walk for over a mile when suddenly you hear the beating of large wings directly above you. Looking up, you are shocked to see the sinister black outline of a Kraan diving to attack you.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 229,
                content : "If you draw your weapon and prepare to fight, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 99,
                content : "If you evade the attack by running south, deeper into the forest, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 86
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 86,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "You soon reach another crossroads",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 6,
                content : "If you wish to journey east, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 35,
                content : "If you wish to head north, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 167,
                content : "If you prefer to go south, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 42,
                content : "Or if you wish to turn west, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 87
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 87,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Graveyard of the Ancients",
            regionType : "GRAVEYARD",
            description : "The Graveyard of the Ancients is an ancient, mist-shrouded graveyard just North of Holmgard. This place is taboo because of the nameless horrors that inhabit it. No one knows who lies in eternal unrest here but the Evil that lives there is more ancient than the Darklords.",
            imageUrl : "images/flight/regions/graveyardofancients.png"
         },
         content : "Focusing your powers on the lock, you try to visualize the inner mechanism. Gradually its image appears in your mind’s eye. It is old and corroded but it still functions. You are in danger of losing your concentration when a subtle click confirms that your effort has not been in vain. The pin is an easier task. Slowly it rises out of the lock and falls to the floor. The granite door swings towards you on hidden hinges and the grey half-light of the Graveyard floods into the tomb. The exit is overgrown with graveweed and you suffer many small cuts to your face and hands as you fight your way through to the surface. You are startled by a sudden noise. You turn to see the disembodied head of a corpse laughing at you. In blind panic, you race through the eerie necropolis towards the southern gate.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 61,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 88
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 88,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Dragon Bridge",
            regionType : "BRIDGE",
            description : "The Dragon Bridge connects the northern and southern part of Summerlund.",
            imageUrl : "images/flight/regions/dragonbridge.png"
         },
         content : "You cautiously peer around the rock to see a soldier lying on his back. By his side is a Spear and shield. On the shield is the painting of a white pegasus—the Prince of Sommerlund’s emblem. He is one of the Prince’s soldiers, and he is only just conscious. His uniform is badly torn, and you can see that he has a deep wound in his left arm. As you move nearer, his eyes flicker open. Heal me, my lord, he begs. I can barely feel my arm.",
         outcomes :  [
            {
                outcomeType : "ABILITY",
                targetNr : 216,
                ability : {
                    abilityType : "HEALING",
                    description : "This Discipline can be used to restore ENDURANCE points lost in combat. If you possess this skill you may restore 1 ENDURANCE point to your total for every numbered section of the book you pass through in which you are involved in combat. (This is only to be used after your ENDURANCE has fallen below its original level.) Remember that your ENDURANCE cannot rise above its original level."
                },
                content : "If you possess and wish to use the Kai Discipline of Healing on this man, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 31,
                content : "If you do not possess the skill, or if you do not want to use it, then turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 89
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 89,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "In a cloud of dust and loose rocks you career down the steep hillside. The Kraan is still circling above as if waiting to direct the Giaks after you. Pick a number from the Random Number Table. ",
         outcomes :  [
            {
                outcomeType : "RANDOM",
                targetNr : 53,
                intervall : {
                    min : 0,
                    max : 1
                },
                content : "If you have picked 0–1, turn to "
            }, {
                outcomeType : "RANDOM",
                targetNr : 274,
                intervall : {
                    min : 2,
                    max : 4
                },
                content : "If it is 2–4, turn to "
            }, {
                outcomeType : "RANDOM",
                targetNr : 316,
                intervall : {
                    min : 5,
                    max : 9
                },
                content : "If it is 5–9, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 90
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 90,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Silvermoon Lake",
            regionType : "LAKE",
            description : "The Silvermoon Lake is a ...",
            imageUrl : "images/flight/regions/silvermoonlake.png"
         },
         content : "Night falls and you are soon engulfed in total darkness. To press on would be useless, for you would be sure to lose your way. Tethering your horse to a tree, you pull your green Kai cloak about you and fall into a restless sleep.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 18,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 91
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 91,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Holmgard",
            regionType : "CITY",
            description : "Holmgard is the capital of Sommerlund and is a seaport on the Holmgulf. It is located near the Graveyard of the Ancients. The city is enclosed by grey-white walls two hundred feet in height whose gatehouses are 100 yards long. At the center of the city is the Citadel of the King.",
            imageUrl : "images/flight/regions/holmguard.png"
         },
         content : "The small shop is dark and musty. Books and bottles of every size and colour fill the many shelves. As you close the door, a small black dog begins to yap at you. A bald man appears from behind a large screen and bids you welcome. He politely enquires as to the nature of your visit and offers you a choice of his wares from the glass counter.",
         outcomes :  [
            {
                outcomeType : "ABILITY",
                targetNr : 198,
                ability : {
                    abilityType : "SIXTH_SENSE",
                    description : "This skill may warn a Kai Lord of imminent danger. It may also reveal the true purpose of a stranger or strange object encountered in your adventure."
                },
                content : "If you have the Kai Discipline of Sixth Sense, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 152,
                content : "If you wish to look at his wares, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 7,
                content : "If you would rather decline his offer and return to the street, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 92
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 92,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "You dive for cover not a moment too soon, for a hail of black arrows scream out of the woods and bombard the area where you were standing seconds before. Pulling your cloak around you to blend into the dense bracken, you dash through the forest and away from the hidden ambushers as fast as possible. This entire area is infested by Giaks and you must escape as quickly as you can. You run without rest for over an hour until you happen to fall upon a straight forest path heading towards the east. You follow the path, taking care to keep watch for signs of the enemy.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 13,
                content : "Turn to"
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 93
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 93,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "You turn and run for the stairs just as a large block falls with a crash behind you. The room you were in has been completely sealed off. As you escape into the daylight, you glimpse behind you the crooked figure of an old druid as he raises his staff. A second later, a bolt of lightning explodes at your feet. You do not stop but run headlong down the hill, cursing the delay but thankful for your Sixth Sense.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 106,
                content : "Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 94
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 94,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         content : "The Sage, seeing that you have killed his son, turns and runs from the shop by a back door. You find 12 Gold Crowns in the robber’s purse and another 4 Gold Crowns in a wooden box under the counter. Carefully examining the potions and the wand you soon realize that they are all cheap counterfeits. In fact the entire shop is full of imitations. You shake your head and return to the main street.",
         events : [
            {
                eventType : "CHANGE_GOLD_AMOUNT_EVENT",
                ranking : 1,
                amount : 16
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 7,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 95
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 95,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "You soon stumble upon a narrow forest track running from north to south.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 240,
                content : "If you wish to set off along the track towards the north, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 5,
                content : "If you wish to go south instead, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 96
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 96,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         content : "Holding your breath, you tighten your grip on your weapon and prepare to strike. The tension is unbearable—the Giaks are so close that the foul stench of their unwashed bodies fills your nostrils. You hear them curse in their strange alien tongue and then leave the ledge and start to scramble towards the peak. When you are sure they have gone, you finally exhale and wipe the sweat from your eyes.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 33,
                content : "If you wish to explore the cave further, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 248,
                content : "If you wish to leave the cave and descend the hill in case the Giaks return, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 97
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 97,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Dragon Bridge",
            regionType : "BRIDGE",
            description : "The Dragon Bridge connects the northern and southern part of Summerlund.",
            imageUrl : "images/flight/regions/dragonbridge.png"
         },
         content : "Ahead of you, you can see a fierce battle raging across a stone bridge. The clash of steel and the cries of men and beasts echo through the forest. In the midst of the fighting, you see Prince Pelathar, the King’s son. He is in combat with a large grey Gourgaz who is wielding a black axe above his scaly head. Suddenly, the Prince falls wounded—a black arrow in his side.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 255,
                content : "If you wish to defend the fallen Prince, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 306,
                content : "If you wish to run into the forest, turn to "
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 98
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 98,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Inner Courtyard",
            regionType : "STONE_BUILDING",
            description : "The inner courtyard is a bustle of activity. Cavalry scouts are waiting beside their nervous horses for messages from their unit commanders inside the  Great Hall. They  take orders with great speed to the defenders of the outer fieldworks.",
            imageUrl : "images/flight/regions/stonebuilding.png"
         },
         content : "The guards seem to believe your story and bow with respect to your rank of Kai Lord. One of them pulls a concealed bell-rope and the huge doors start to swing open. They usher you inside and you hear the doors close behind you.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 139,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 99
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 99,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "You dive into the undergrowth just as the beast screams past your head. You quickly look back to see the Kraan turning in the air in preparation for another dive. You scramble to your feet and run deeper into the safety of the forest.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 222,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 100
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 100,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Graveyard of the Ancients",
            regionType : "GRAVEYARD",
            description : "The Graveyard of the Ancients is an ancient, mist-shrouded graveyard just North of Holmgard. This place is taboo because of the nameless horrors that inhabit it. No one knows who lies in eternal unrest here but the Evil that lives there is more ancient than the Darklords.",
            imageUrl : "images/flight/regions/graveyardofancients.png"
         },
         content : "The cold corridor suddenly makes an abrupt turning towards the east. You notice a greenish glow that lights the tunnel in the far distance. As you creep nearer you can see that the corridor opens out into a larger chamber. The strange light seems to emanate from a large bowl resting upon the top of a granite throne. On a plinth in front of the throne stands a statue. It looks like a winged serpent curved in the shape of an ‘S’.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 161,
                content : "If you wish to sit on the throne, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 133,
                content : "If you wish to examine the statue, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 257,
                content : "If you wish to look for an exit from this chamber, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 101
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 101,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "The noise of battle soon fades behind you but the ensuing silence is broken by a voice in your head that accuses you of being a coward, and deserting a fellow human in danger. You try to rid yourself of your nagging conscience by telling yourself that your mission is far more important, and that not only is the life of the young magician in peril but the lives of all your countrymen depend on you reaching the capital alive. Suddenly, the sight of a Giak war party in the distance makes you quickly take cover and hide. But it is too late—they have spotted you and you must run as fast as you can.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 281,
                content : "Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 102
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 102,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Graveyard of the Ancients",
            regionType : "GRAVEYARD",
            description : "The Graveyard of the Ancients is an ancient, mist-shrouded graveyard just North of Holmgard. This place is taboo because of the nameless horrors that inhabit it. No one knows who lies in eternal unrest here but the Evil that lives there is more ancient than the Darklords.",
            imageUrl : "images/flight/regions/graveyardofancients.png"
         },
         content : "As you descend the rocky slope towards the Graveyard of the Ancients, you are aware of a strange mist and cloud that swirls all around this grey and forbidding place, blocking the sun and covering the Graveyard in a perpetual gloom. A chill creeps forward to greet your approach. With a feeling of deep dread, you enter the eerie necropolis.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 284,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 103
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 103,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "The overgrown path leads to a junction where another track branches off towards the east.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 13,
                content : "If you wish to take this path, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 287,
                content : "If you would rather continue towards the northeast, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 104
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 104,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Graveyard of the Ancients",
            regionType : "GRAVEYARD",
            description : "The Graveyard of the Ancients is an ancient, mist-shrouded graveyard just North of Holmgard. This place is taboo because of the nameless horrors that inhabit it. No one knows who lies in eternal unrest here but the Evil that lives there is more ancient than the Darklords.",
            imageUrl : "images/flight/regions/graveyardofancients.png"
         },
         content : "The walls are dank and slimy. The stale air chokes you and cobwebs brush across your face. You can feel panic grip your stomach, as the tunnel gets darker and darker. You reach a junction where the tunnel meets a corridor leading from north to south.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 26,
                content : "If you wish to turn north, go to "
            },  {
                outcomeType : "DEFAULT",
                targetNr : 100,
                content : "If you wish to go south, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 105
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 105,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "In the distance, perched on the branch of an old oak tree is a jet-black raven.",
         outcomes :  [
            {
                outcomeType : "ABILITY",
                targetNr : 298,
                ability : {
                    abilityType : "ANIMAL_KINSHIP",
                    description : "This skill enables a Kai Lord to communicate with some animals and to be able to guess the intentions of others."
                },
                content : "If you have the Kai Discipline of Animal Kinship, you may call to this bird by turning to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 335,
                content : "If you do not possess this skill, or if you do not wish to use it, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 106
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 106,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Clearing",
            regionType : "CLEARING",
            description : "You pass through a long, dark tunnel of voerhanging branches that eventually opens out into a large clearing.",
            imageUrl : "images/flight/regions/clearing.png"
         },
         content : "Eventually you come to the edge of a fast-flowing icy stream. The white water cascades over the mossy rocks and disappears towards the east.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 263,
                content : "If you wish to follow the stream to the east, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 334,
                content : "If you would rather explore upstream, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 107
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 107,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Graveyard of the Ancients",
            regionType : "GRAVEYARD",
            description : "The Graveyard of the Ancients is an ancient, mist-shrouded graveyard just North of Holmgard. This place is taboo because of the nameless horrors that inhabit it. No one knows who lies in eternal unrest here but the Evil that lives there is more ancient than the Darklords.",
            imageUrl : "images/flight/regions/graveyardofancients.png"
         },
         content : "Running across the room, you lash out at the skulls, smashing them to fragments. You notice that inside each skull is a bubbling grey jelly that seems to writhe and change its shape, sprouting bat-like wings and suckers from its glistening form. In horror and loathing, you race for the exit corridor and escape just as a heavy portcullis falls with a crash, completely sealing off the chamber.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 23,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 108
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 108,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Homgard Robbers Lane",
            regionType : "CITY",
            description : "The Homgard Robbers Lane is...",
            imageUrl : "images/flight/regions/holmguardupperlane.png"
         },
         content : "You fly in an arc through the air towards the opposite roof. Everything seems to be happening in slow motion. You see the teeming crowds below in the street, and a nest of callysparrows in the eaves of a roof to your right. You hear their startled cries as you land with a crash on the other side. But it is the last sound that you will ever hear. The tiles splinter and collapse and you fall through the four floors of the ‘Green Slipper Inn’ breaking your back in several places. Your mission and your life end here.",
         events :  [
            {
                eventType : "MISSION_FAILED_EVENT",
                ranking : 1
            }
         ]
    },
 {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 109
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 109,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "The only thing under the carpet is dirt!",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 164,
                content : "You may take a closer look at the bottles by turning to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 308,
                content : "Or you can leave the room and investigate the stable by turning to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 110
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 110,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         content : "You quickly take aim and hurl the rock at the Giak’s head as hard as you can, but to your horror the creature ducks and the rock arcs harmlessly over its back. You must act immediately to save the wizard.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 55,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 111
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 111,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "Only a few minutes after leaving the junction, you see in the distance a small log cabin and stable. On arrival you check the interior through a side window. The cabin looks deserted.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 57,
                content : "If you wish to enter the cabin, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 308,
                content : "If you wish to search the stable, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 112
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 112,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Clearing",
            regionType : "CLEARING",
            description : "You pass through a long, dark tunnel of voerhanging branches that eventually opens out into a large clearing.",
            imageUrl : "images/flight/regions/clearing.png"
         },
         content : "Suddenly, the large rock you are hiding behind is rolled aside and you are faced by two snarling Giaks intent on your death. The cave mouth is a narrow entrance and you can only fight the Giaks one at a time.",
         events : [
            {
                eventType : "COMBAT",
                ranking : 1,
                creature : {
                    name : "Giak",
                    combatSkill : 13,
                    endurance : 10,
                    imageUrl : "images/flight/creatures/giak.png"
                }
            }, {
                eventType : "COMBAT",
                ranking : 2,
                creature : {
                    name : "Giak",
                    combatSkill : 13,
                    endurance : 10,
                    imageUrl : "images/flight/creatures/giak.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 33,
                content : "If you win, you may explore the cave further by turning to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 248,
                content : "Or you may leave and descend the hill. Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 113
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 113,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "You have been walking for over half an hour when your eye is caught by some bright red flowers growing near to a mossy bank. You recognize the plants to be Laumspur, a rare and beautiful herb much prized for its healing properties. Kneeling down, you pick a handful of Laumspur and place it in your Backpack. You may eat this herb to regain lost ENDURANCE points. Each Meal of Laumspur will restore 3 ENDURANCE points, and you have gathered enough for two such Meals.1 Closing your pack, you continue your mission.",
         events : [
            {
                eventType : "ACQUIRE_ITEM_EVENT",
                ranking : 1,
                item : {
                    name : "Laumspur",
                    itemType : "HERB",
                    description : "Each Meal of Laumspur may be consumed when prompted for a Meal, in which case it fulfills teh Meal re...",
                    weight : "SMALL",
                    imageUrl : "images/flight/items/.png"
                }
            }, {
                eventType : "ACQUIRE_ITEM_EVENT",
                ranking : 2,
                item : {
                    name : "Laumspur",
                    itemType : "HERB",
                    description : "Each Meal of Laumspur may be consumed when prompted for a Meal, in which case it fulfills teh Meal re...",
                    weight : "SMALL",
                    imageUrl : "images/flight/items/.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 347,
                content : "If you wish to head northeast, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 295,
                content : "If you wish to head east, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 114
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 114,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Silvermoon Lake",
            regionType : "LAKE",
            description : "The Silvermoon Lake is a ...",
            imageUrl : "images/flight/regions/silvermoonlake.png"
         },
         content : "You coax the horse to lie down and begin to cover him and yourself with branches and dead leaves. You hear the wings of the Kraan as it passes over the trees. It returns and circles above you, but soon retreats back across the lake. You decide to leave now, in case it returns with some of its friends.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 239,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 115
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 115,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Boat Crossing",
            regionType : "CITY_OUTSKIRTS",
            description : "The outer fildworks of the city can now be seen.",
            imageUrl : "images/flight/regions/holmguardoutskirts.png"
         },
         content : "You stumble into the first building and fall to the floor exhausted. You can smell cooked meat. You notice a small cauldron hanging over the embers of a dying fire, and a large oak table that has been set for a meal. Whoever lived here must have left in a great hurry this very morning. There is water in a jug and a loaf of fresh bread on the table.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 150,
                content : "If you decide to take a quick Meal, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 177,
                content : "If you decide to search the building, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 83,
                content : "If you would rather leave now and continue your run, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 116
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 116,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Silvermoon Lake",
            regionType : "LAKE",
            description : "The Silvermoon Lake is a ...",
            imageUrl : "images/flight/regions/silvermoonlake.png"
         },
         content : "As you climb out of the muddy water, black arrows fall all around you. Quickly, you dash for the cover of the trees and wait for the Giaks to leave the opposite bank, before continuing on foot towards the capital.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 321,
                content : "Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 117
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 117,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Dragon Bridge",
            regionType : "BRIDGE",
            description : "The Dragon Bridge connects the northern and southern part of Summerlund.",
            imageUrl : "images/flight/regions/dragonbridge.png"
         },
         content : "The man is badly injured and near to death. If you have the Kai Discipline of Healing, you may ease the pain of his wounds but he has been so seriously hurt he is beyond repair by your skills alone. He soon lapses into unconsciousness. You try to make him as comfortable as possible beneath a large forest oak, before leaving and pressing on through the thick woodland towards the northeast.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 330,
                content : "Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 118
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 118,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Boat Crossing",
            regionType : "CITY_OUTSKIRTS",
            description : "The outer fildworks of the city can now be seen.",
            imageUrl : "images/flight/regions/holmguardoutskirts.png"
         },
         content : "You spur your horse to a gallop and race down the long straight path. In the far distance you can just make out the silhouette of Holmgard on the horizon, its high walls and tall spires glinting in the morning sun. Your path joins a highway running from north to south. It is the main turnpike road between the northern port of Toran and the capital. You set off towards Holmgard, your eyes peeled for Kraan in the clear morning sky.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 224,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 119
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 119,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         content : "",
         events :  [
            {
                eventType : "CHANGE_ENDURANCE_EVENT",
                ranking : 1,
                amount : -2
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 226,
                content : "If you wish to slide down the slope as carefully as you can, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 38,
                content : "If you do not feel that you are up to the risk of this tricky descent in your present sleepy state, walk around the edge of the ridge by turning to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 120
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 120,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         content : "Behind you can hear the blood-crazy Giaks killing the caravan horses. You risk a quick glance over your shoulder and see a Kraan start to climb high into the air. Will it attack you or is it interested in something else? The dark shadow that is gradually getting larger all around you tells you that you are its intended victim. The Kraan is diving full speed at you!",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 84,
                content : "If you wait until it is about to strike and then jump from the saddle, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 171,
                content : "If you head as fast as you can for the trees, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 54,
                content : "If you put your head down, pray to the heavens for good luck and gallop on regardless, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 121
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 121,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "After a few minutes walking you see a stranger, clad in red, standing in the centre of the track ahead. He has his back towards you, and his head is covered by the hood of his robes. Perched on his outstretched arm is the black raven that you saw earlier.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 342,
                content : "If you wish to call the stranger, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 309,
                content : "If you wish to approach the stranger cautiously, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 283,
                content : "If you would rather draw your weapon and attack, turn to "
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 122
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 122,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "Immediately the horse senses your communication. He calms down. You walk towards the beautiful animal and stroke his head reassuringly. You sense that he is frightened and confused. Mounting him, you lead him off to the path and head south once again.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 206,
                content : "Turn to "
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 123
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 123,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
          region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "As the creature dies, its body slowly dissolves into a vile green liquid. You notice that all of the grass and the plants beneath the smoking fluid are beginning to shrivel and die. A large valuable looking Gem lies on the ground near to the decaying body. Further along the track you can see a large war party of Giaks running towards you.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 304,
                content : "If you wish to take the Gem, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 2,
                content : "If you would rather leave it and run, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 124
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 124,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Clearing",
            regionType : "CLEARING",
            description : "You pass through a long, dark tunnel of voerhanging branches that eventually opens out into a large clearing.",
            imageUrl : "images/flight/regions/clearing.png"
         },
         content : "Inside the box you find 15 Gold Crowns and a Silver Key. If you wish to keep the key, remember to mark it on your Action Chart.",
         events :  [
            {
                eventType : "CHANGE_GOLD_AMOUNT_EVENT",
                ranking : 1,
                amount : 15
            }, {
                eventType : "ACQUIRE_ITEM_EVENT",
                ranking : 2,
                item : {
                    name : "Silver Key",
                    itemType : "KEY",
                    description : "Silver Key",
                    weight : "SMALL",
                    imageUrl : "images/flight/items/silverkey.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 211,
                content : "You can continue to investigate the tunnel by turning to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 106,
                content : "Or you may leave and descend the hill by turning to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 125
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 125,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Clearing",
            regionType : "CLEARING",
            description : "You pass through a long, dark tunnel of voerhanging branches that eventually opens out into a large clearing.",
            imageUrl : "images/flight/regions/clearing.png"
         },
         content : "The path opens out into a large clearing. You notice strange claw prints in the earth. Kraan have landed here. By the number of prints and by the size of the area disturbed, you judge that at least five of the foul creatures landed here in the last twelve hours. You see two exits on the far side of the clearing. One leads west, the other south.",
         outcomes :  [
            {
                outcomeType : "ABILITY",
                targetNr : 301,
                ability : {
                    abilityType : "TRACKING",
                    description : "This skill enables a Kai Lord to make the correct choice of a path in the wild, to discover the location of a person or object in a town or city and to read the secrets of footprints or tracks."
                },
                content : "If you have the Kai Discipline of Tracking, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 27,
                content : "If you wish to take the south path, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 214,
                content : "If you wish to take the west path, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 126
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 126,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Silvermoon Lake",
            regionType : "LAKE",
            description : "The Silvermoon Lake is a ...",
            imageUrl : "images/flight/regions/silvermoonlake.png"
         },
         content : "You ride deeper and deeper into the forest. Silently you thank the Prince for such a fine horse, for although the ground is a tangle of briars and roots, he never once falters. The Doomwolves are soon left far behind and you bring your horse to a halt. The light has faded fast and it is almost night.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 46,
                content : "If you wish to press on ahead, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 143,
                content : "If you wish to bear left (the same direction as the path you left far behind) then turn to "
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 127
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 127,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "After an hour of marching, the Drakkarim suddenly halt as a large, grey scaly creature approaches along the track. As the beast draws closer, you can smell its fetid breath on your face. It lets out a roar and grabs your head in its powerful webbed hands. The last thing you hear is the sharp crack of your spine snapping. Your quest ends here.",
         events :  [
            {
                eventType : "MISSION_FAILED_EVENT",
                ranking : 1
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 128
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 128,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "Carefully parting the dense foliage, you are horrified by the sight that meets you. In a small clearing ahead, three Giaks have tied a man to a wooden stake and are setting fire to a mass of brushwood bundled at his feet. You recognize his tunic as that of a Border Ranger, one of the King’s men who police the kingdom near the Durncrag Mountains of the west. He has been badly beaten and is nearly unconscious.",
         outcomes :  [
            {
                outcomeType : "ABILITY",
                targetNr : 297,
                ability : {
                    abilityType : "HUNTING",
                    description : "This skill ensures that a Kai Lord will never starve in the wild. He will always be able to hunt for food for himself except in areas of wasteland and desert. The skill also enables a Kai Lord to be able to move stealthily when stalking his prey."
                },
                content : "If you have the Kai Discipline of Hunting, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 336,
                content : "If you do not, you must attack the Giaks now in order to save the ranger’s life. Turn to"
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 129
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 129,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Holmgard",
            regionType : "CITY",
            description : "Holmgard is the capital of Sommerlund and is a seaport on the Holmgulf. It is located near the Graveyard of the Ancients. The city is enclosed by grey-white walls two hundred feet in height whose gatehouses are 100 yards long. At the center of the city is the Citadel of the King.",
            imageUrl : "images/flight/regions/holmguard.png"
         },
         content : "You reach the main gates of the capital, and stare in awe at the height of the city’s walls. Two hundred feet high, the walls of Holmgard have withstood the ravages of both time and the Darklords. You and the officer race through the tunnel of the inner gatehouse, one hundred yards in length, and finally halt outside the doorway of the main watchtower. Great crowds of soldiers and civilians are running to and from.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 3,
                content : "If you wish to continue following the officer, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 144,
                content : "If you feel that you stand a better chance of making your way to the King’s citadel on your own, turn to "
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 130
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 130,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Wafford Clearing",
            regionType : "CLEARING",
            description : "You soon reach a small clearing in the woods.",
            imageUrl : "images/flight/regions/waffordclearing.png"
         },
         content : "You soon reach a small clearing in the woods. A bench, carved from a fallen tree is set in the centre of the clearing. You are hungry and must now eat a Meal here.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 28,
                content : "When you have finished, if you decide to leave the clearing by the south way, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 201,
                content : "Or if you prefer the smaller track that leads eastwards into the forest, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 131
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 131,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Ruins of Raumas",
            regionType : "TEMPLE_RUIN",
            description : "Edging nearer, you soon make out a clearing that you recognize to be the site of the ruins of Raumas.",
            imageUrl : "images/flight/regions/runinsofraumas.png"
         },
         content : "You have covered about a quarter of a mile when you hear shouting and a noise like thunderclaps ahead. Edging nearer, you soon make out a clearing that you recognize to be the site of the ruins of Raumas, an ancient forest temple. A war party of Giaks, some twenty-five to thirty strong, are attacking the ruins from all sides. Many more of the Giaks are dead or dying among the broken pillars of marble, but still they assault whatever is hidden inside. Suddenly, a bolt of blue lightning rips through the front rank of Giaks sending the armour-clad creatures tumbling in all directions.  A Giak, taller than the others and dressed from head to foot in black chainmail, curses at his troops as he whips them forward with a barbed flail. With weapon ready, you move to the edge of the clearing, under cover of the thick foliage, and try to catch a glimpse of the defenders. To your amazement, the ruins are being defended by a young man no older than yourself. You recognize his sky-blue robes, embroidered with stars. He is a young theurgist of the Magicians’ Guild of Toran: an apprentice in magic. Five Giaks charge forward, their spears raised to stab the apprentice as he hurriedly retreats deeper into the ruins. You see him turn and raise his left hand just before a bolt of blue flame shoots from his fingertips into the snarling Giak soldiers. Close to where you are hidden, you see a Giak scuttle past and climb one of the pillars of the temple. He has a long curved dagger in his mouth and he is about to jump on the young wizard standing below.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 241,
                content : "If you wish to shout a warning to the wizard, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 55,
                content : "If you wish to run forward and attack the Giak when he jumps, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 302,
                content : "If you wish to pick up a chunk of temple marble and throw it at the Giak’s head, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 101,
                content : "Or if you would rather turn and leave the battle area and run back into the woods, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 132
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 132,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "The bodyguard looks at you with great suspicion and slams the door. You can hear voices chattering inside the caravan. Suddenly the door swings open and the face of a wealthy merchant appears. He recognizes your Kai cloak and apologizes for his servant’s behaviour. He says that they have been attacked several times since they left Toran: by Kraan, by bandits, and by robbers. They thought you may have been a bandit. Inside, the caravan is full of silks and spices. The merchant offers you food which you gratefully accept. After your sumptuous meal, the fatigue of your ordeal finally overcomes you and you slip into a deep sleep.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 64,
                content : "Turn to "
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 133
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 133,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Graveyard of the Ancients",
            regionType : "GRAVEYARD",
            description : "The Graveyard of the Ancients is an ancient, mist-shrouded graveyard just North of Holmgard. This place is taboo because of the nameless horrors that inhabit it. No one knows who lies in eternal unrest here but the Evil that lives there is more ancient than the Darklords.",
            imageUrl : "images/flight/regions/graveyardofancients.png"
         },
         content : "As you approach the statue, several cracks appear in its stone surface. It suddenly explodes before you as a real Winged Serpent breaks free of its stone mantle and attacks you. You must fight the creature.",
         events :  [
            {
                eventType : "COMBAT",
                ranking : 1,
                creature : {
                    name : "Winged Serpent",
                    combatSkill : 16,
                    endurance : 18,
                    imageUrl : "images/flight/creatures/wingedserpent.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 266,
                content : "If you win the fight, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 134
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 134,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "Using your skills, you detect Giak tracks around the perimeter of the clearing. The prints are fresh and you can tell that these cruel minions of the Darklords were in this area less than two hours ago.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 305,
                content : "Forewarned by this knowledge, if you decide to investigate the huts, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 40,
                content : "If you would rather avoid the clearing, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 135
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 135,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Riverbank",
            regionType : "RIVER_BANK",
            description : "Peering over the steep undercut of the riverbank, you can see a tanble of driftwood along the waters edge.",
            imageUrl : "images/flight/regions/riverbank.png"
         },
         content : "Peering over the steep undercut of the river bank, you can see a tangle of driftwood along the water’s edge. A large tree trunk has grounded on the clay bank next to a small canoe.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 223,
                content : "If you wish to use the log to float down the river, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 4,
                content : "If you wish to use the canoe, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 136
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 136,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "The Giaks get nearer and then crouch down as if preparing themselves to pounce. You can see the sharp serrated points of their spears and hear their low guttural speech. The larger of the two creatures screams, ‘Orgadak taag! Nogjat aga ok!’ and attacks you. You must fight each of the Giaks in turn. Add 1 point to your COMBAT SKILL during this fight, as you have the advantage of the higher ground in your favour.",
         events :  [
            {
                eventType : "COMBAT",
                ranking : 1,
                creature : {
                    name : "Giak",
                    combatSkill : 9,
                    endurance : 10,
                    imageUrl : "images/flight/creatures/giak.png"
                }
            }, {
                eventType : "COMBAT",
                ranking : 2,
                creature : {
                    name : "Giak",
                    combatSkill : 8,
                    endurance : 12,
                    imageUrl : "images/flight/creatures/giak.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 313,
                content : "If you win, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 137
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 137,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Graveyard of the Ancients",
            regionType : "GRAVEYARD",
            description : "The Graveyard of the Ancients is an ancient, mist-shrouded graveyard just North of Holmgard. This place is taboo because of the nameless horrors that inhabit it. No one knows who lies in eternal unrest here but the Evil that lives there is more ancient than the Darklords.",
            imageUrl : "images/flight/regions/graveyardofancients.png"
         },
         content : "As the last of the foul creatures die, so the greenish light starts to fade. You notice that in each of the broken skulls lies a Gem. You take these 20 Tomb Guardian Gems before darkness engulfs the chamber. Remember to mark these on your Action Chart as a single Backpack Item. You quickly leave the dead Crypt spawn and press on.",
         events :  [
            {
                eventType : "ACQUIRE_ITEM_EVENT",
                ranking : 1,
                item : {
                    name : "Guardian Gems",
                    itemType : "GEM",
                    description : "Guardian Gems from crypt ...",
                    weight : "SMALL",
                    imageUrl : "images/flight/items/guardiangem.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 23,
                content : "Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 138
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 138,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "You prepare your weapon and advance to meet the enemy. There are two Mountain Giaks and you must fight them one at a time.",
         events :  [
            {
                eventType : "COMBAT",
                ranking : 1,
                creature : {
                    name : "Giak",
                    combatSkill : 9,
                    endurance : 10,
                    imageUrl : "images/flight/creatures/giak.png"
                }
            }, {
                eventType : "COMBAT",
                ranking : 2,
                creature : {
                    name : "Giak",
                    combatSkill : 8,
                    endurance : 12,
                    imageUrl : "images/flight/creatures/giak.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 291,
                content : "If you win, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 139
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 139,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         content : "The inner courtyard is a bustle of activity. Cavalry scouts are waiting beside their nervous horses for messages from their unit commanders inside the Great Hall. They take orders with great speed to the defenders of the outer fieldworks. No sooner do they gallop off, than other scouts return, many of them breathless and wounded. You have taken less than a dozen steps across the courtyard when you hear a deep voice boom out. ‘Stop that man!’",
         region : {
            name : "Inner Courtyard",
            regionType : "STONE_BUILDING",
            description : "The inner courtyard is a bustle of activity. Cavalry scouts are waiting beside their nervous horses for messages from their unit commanders inside the  Great Hall. They  take orders with great speed to the defenders of the outer fieldworks.",
            imageUrl : "images/flight/regions/stonebuilding.png"
         },
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 66,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 140
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 140,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Old Watch Tower",
            regionType : "WOOD_BUILDING",
            description : "The old Watchtower is ...",
            imageUrl : "images/flight/regions/ruinwatchtower.png"
         },
         content : "You are in a clearing where several trees have been cut down to make a rickety watchtower. Below the tower are three paths leading off in different directions.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 14,
                content : "If you take the south path, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 252,
                content : "If you take the east path, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 215,
                content : "If you take the southwest path, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 36,
                content : "If you decide to climb the watchtower, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 141
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 141,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "Your Sixth Sense has warned you that some of the creatures that attacked the monastery are searching the two paths for any survivors of their raid, but you can avoid both tracks by making your way through the undergrowth of the woods.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 56,
                content : "If you wish to head south, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 333,
                content : "Or if you wish to cut through the heavier foliage towards the northeast, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 142
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 142,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Boat Crossing",
            regionType : "CITY_OUTSKIRTS",
            description : "The outer fildworks of the city can now be seen.",
            imageUrl : "images/flight/regions/holmguardoutskirts.png"
         },
         content : "You can see the tall grey-white walls and glimmering spires of Holmgard, its banners fluttering from the battlements in the fresh morning breeze. Stretching out towards the west, the River Eledil traces its course from the mountains of the Durncrag Range to the Holmgulf. But from below the mountain peaks you can see a vast black army marching relentlessly on towards the city. To your right you can see the highway heading off over the rolling plain towards Holmgard. At a run you could reach the outer fieldworks of the city defences in an hour, but you would be in the open for most of the time and vulnerable to attack by Kraan. However, ahead of you, a wide and muddy river drifts sluggishly towards the Eledil. You could use the cover of the river banks and swim towards the capital. Or towards your left lies the Graveyard of the Ancients. These tombs and crumbling monuments to a forgotten age would conceal your approach, but it is a forbidden area. Many are the unnamed horrors that lie there in restless sleep, waiting to consume the unwary trespasser.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 58,
                content : "If you will try your luck by the highway, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 135,
                content : "If you feel that you stand a better chance of reaching the capital via the river, then turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 102,
                content : "Or if you are brave enough to risk the unknown perils of the Graveyard of the Ancients, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 143
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 143,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "You soon emerge from the woods onto a main highway. You recognize it as being the main road between the port of Toran in the north and the capital in the south. Spurring your horse on, you estimate you will reach the capital by morning.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 149,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 144
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 144,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Kings Citadel",
            regionType : "CITADEL",
            description : "The Kings Citadel is the highest law enforcement and paramilitary organization in Holmgard.",
            imageUrl : "images/flight/regions/holmguardcitadel.png"
         },
         content : "You fight your way through the press of bodies along the main street towards the citadel in the distance. City folk are rushing to and fro in the grip of panic, as the cries of Kraan are heard circling high above. In the crush, one item is stolen from your Backpack. If you no longer have a Backpack or if you have no Backpack Items, you lose a Weapon. Remember to take this off your Action Chart. A runaway horse and cart career past and knock you into a doorway. You are stunned and you lose 2 ENDURANCE points. As you stagger to your feet, the door bursts open and a decrepit old man attacks you with a meat cleaver. He is quite insane and you must fight him or take evasive action.",
         events :  [
            {
                eventType : "CHANGE_ENDURANCE_EVENT",
                ranking : 1,
                amount : -2
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 63,
                content : "If you choose to fight, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 217,
                content : "If you wish to evade a fight, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 145
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 145,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Holmgard",
            regionType : "CITY",
            description : "Holmgard is the capital of Sommerlund and is a seaport on the Holmgulf. It is located near the Graveyard of the Ancients. The city is enclosed by grey-white walls two hundred feet in height whose gatehouses are 100 yards long. At the center of the city is the Citadel of the King.",
            imageUrl : "images/flight/regions/holmguard.png"
         },
         content : "You feel as if you have been run down by a cart or wagon. As you fall forward the last thing that you remember before the darkness overcomes you, is the taste of the sandy road and the terrible pain in your back.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 165,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 146
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 146,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "You have ridden about a mile when you are knocked from your horse by an arrow grazing your forehead. You lose 3 ENDURANCE points. As you pull yourself to your feet, you see a patrol of Drakkarim emerge from the woods on either side of the road. You have been ambushed and must evade them as quickly as possible by going into the forest.",
         events :  [
            {
                eventType : "CHANGE_ENDURANCE_EVENT",
                ranking : 1,
                amount : -3
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 154,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 147
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 147,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
          region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "After a few minutes walking, you find a mossy hut set back from the path. You are hungry and must eat a Meal here or lose 3 ENDURANCE points. As you eat you notice that the path starts to curve towards the east.",
         events :  [
            {
                eventType : "CHANGE_RATION_AMOUNT_EVENT",
                ranking : 1,
                amount : -1
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 42,
                content : "If you wish to follow it, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 28,
                content : "If you wish to return the way you have come, turn to "
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 148
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 148,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "Kicking open the door, you dive into the farmhouse. A Kraan soars overhead, letting out a shriek of victory, a victim hanging in its claws. Getting to your feet, you find yourself alone. But propped against the fireplace is a Warhammer. You may take this Weapon if you wish.",
         events :  [
            {
                eventType : "ACQUIRE_ITEM_EVENT",
                ranking : 1,
                item : {
                    name : "Warhammer",
                    itemType : "WEAPON",
                    description : "warhammer",
                    weight : "HEAVY",
                    imageUrl : "images/flight/items/warhammer.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 81,
                content : "If you want to stay in the farmhouse, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 320,
                content : "If you would feel safer in the forest, you can make a dash by turning to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 199,
                content : "If you wish to search the room further, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 149
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 149,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "As you ride along the highway, you notice that light is getting worse. It will soon be completely dark—and impossible to see any dangers that may lurk ahead. You decide to hide and rest at the wood’s edge until morning. When you are satisfied that no one can see you, you pull your warm green cloak about you and drift off into an uneasy sleep.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 256,
                content : "Turn to "
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 150
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 150,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Boat Crossing",
            regionType : "CITY_OUTSKIRTS",
            description : "The outer fildworks of the city can now be seen.",
            imageUrl : "images/flight/regions/holmguardoutskirts.png"
         },
         content : "Although a little overcooked, the food tastes fine (although it is not enough for a whole Meal) and the clear water slakes your thirst. You have spent nearly half an hour resting in this house when you suddenly realize the delay.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 83,
                content : "Prepare your equipment and leave. Turn to "
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 151
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 151,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Graveyard of the Ancients",
            regionType : "GRAVEYARD",
            description : "The Graveyard of the Ancients is an ancient, mist-shrouded graveyard just North of Holmgard. This place is taboo because of the nameless horrors that inhabit it. No one knows who lies in eternal unrest here but the Evil that lives there is more ancient than the Darklords.",
            imageUrl : "images/flight/regions/graveyardofancients.png"
         },
         content : "If you concentrate on the keyhole, you could move the mechanism of the lock and open it. You can then make the pin levitate and free it from the lockplate, avoiding falling prey to any traps that may be set off as the door unlocks.",
         outcomes :  [
            {
                outcomeType : "ABILITY",
                targetNr : 87,
                ability : {
                    abilityType : "MIND_OVER_MATTER",
                    description : "Mastery of this Discipline enables a Kai Lord to move small objects with his powers of concentration."
                },
                content : "If you wish to use your Kai Discipline of Mind Over Matter to open this lock and levitate the pin, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 337,
                content : "If you wish to remove the pin, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 152
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 152,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Holmgard",
            regionType : "CITY",
            description : "Holmgard is the capital of Sommerlund and is a seaport on the Holmgulf. It is located near the Graveyard of the Ancients. The city is enclosed by grey-white walls two hundred feet in height whose gatehouses are 100 yards long. At the center of the city is the Citadel of the King.",
            imageUrl : "images/flight/regions/holmguard.png"
         },
         content : "The herbalist offers you a selection of special potions. Some increase your strength; some induce invisibility; some give you great powers of stealth; and others give you the power of turning yourself into a gaseous form. The man pulls open the bottom drawer of the counter to reveal a magnificent wand. He says that it is a powerful weapon against all evil creatures, and that it will make you invulnerable in battle. He points to the mystical inscriptions which cover the black staff.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 49,
                content : "If you wish to lean over the counter and read the strange inscriptions, turn to "
            },  {
                outcomeType : "DEFAULT",
                targetNr : 231,
                content : "If you are more interested in the potions, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 153
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 153,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Boat Crossing",
            regionType : "CITY_OUTSKIRTS",
            description : "The outer fildworks of the city can now be seen.",
            imageUrl : "images/flight/regions/holmguardoutskirts.png"
         },
         content : "Before you are the tall grey-white walls and glimmering spires of Holmgard, the city’s banners fluttering from the battlements in the fresh morning breeze. Stretching out towards the west, the River Eledil traces its course from the mountains of the Durncrag Range to the Holmgulf. But below the mountain peaks you can see a vast black army marching relentlessly on towards the capital.To your right you can see the highway heading off over the rolling plain towards Holmgard. At a gallop you could make the outer fieldworks of the city’s defences in less than an hour, but you would be in the open for most of the time and vulnerable to attack by Kraan. Directly ahead of you, a wide river drifts sluggishly towards the Eledil. If you abandoned your horse, you could swim towards the outer defences under cover of the river banks. Or there is a final alternative. To your left lies the Graveyard of the Ancients. These tombs and crumbling monuments to a forgotten age would conceal your approach but it is a forbidden area. Many are the unnamed horrors that lie there in restless sleep, waiting to consume the unwary trespasser.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 202,
                content : "If you will try your luck by the highway, turn to "
            },{
                outcomeType : "DEFAULT",
                targetNr : 135,
                content : "If you feel that you stand a better chance of reaching the capital via the river then turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 329,
                content : "Or if you are brave enough to risk the unknown perils of the Graveyard of the Ancients, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 154
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 154,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "You are dizzy from your wound and you stumble through the trees like a blind man. Suddenly you fall forward as if the ground has been snatched from beneath your feet. You have fallen head-first into a hunting pit. As you look up, you can see four Drakkarim levelling their bows at you, evil sneers spreading simultaneously across their ugly faces. As the world darkens, the last thing you feel is the black shafts of their arrows deep in your chest. You have failed in your mission.",
         events :  [
            {
                eventType : "MISSION_FAILED_EVENT",
                ranking : 1
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 155
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 155,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "As you approach, the group of people stop talking. You can see by their expressions that they recognize your green Kai cloak. Slowly, one of the men extends his hand in friendship and says, ‘My Lord, we had heard a rumour that the Kai were destroyed. Heaven be praised that it is not so. We feared all was lost.’You do not tell them of the destruction of the monastery,  for they are refugees from Toran and have lost everything they owned. Their only hope now is that the Kai Lords will lead an army to victory. You learn that the northern port was attacked from both air and sea, and that the forces of the Darklords far outnumbered the King’s brave garrison. You reassure them that Sommerlund will not fall and wish them luck on their journey ahead.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 70,
                content : "turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 156
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 156,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Silvermoon Lake",
            regionType : "LAKE",
            description : "The Silvermoon Lake is a ...",
            imageUrl : "images/flight/regions/silvermoonlake.png"
         },
         content : "Black arrows embed themselves in the mud all around you. More Giaks have appeared on the steep slope of the river bank and are firing at you. There is no cover on this side of the river.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 294,
                content : "If you wish to dive into the water and swim with the current, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 245,
                content : "If you wish to swim across to the cover of the trees on the other bank, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 157
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 157,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "The forest begins to thin out until finally you can make out a road through the trees ahead. The highway is full of people heading south. Many are wheeling their possessions along on handcarts.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 30,
                content : "If you wish to join the refugees and perhaps learn more of what has happened in the north, turn to"
            },{
                outcomeType : "DEFAULT",
                targetNr : 167,
                content : "If you would prefer to continue to move south but under cover of the trees, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 158
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 158,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region: {
            name : "Darkstone Temple",
            regionType : "EVIL_TEMPLE",
            description : "It was only by an unlucky chance you discovered teh secret temple of a sect of evil druids",
            imageUrl : "images/flight/regions/darkstonetemple.png"
         },
         content : "The Key fits and the lock opens. You pull back the door to find yourself face to face with a strange old man. In his right hand is a staff. Suddenly a bolt of lightning shoots from the staff and hits you square in the chest. You lose 6 ENDURANCE points. Gasping with pain, you knock the old man aside and run up the steep staircase towards daylight. You are halfway up the stairs when he fires another bolt at you. If you survive, you stagger out into the daylight and curse your bad luck. It was only by an unlucky chance you discovered the secret temple of a sect of evil druids. You are very lucky to have escaped with your life. You quickly rejoin the path which now disappears over the hill.",
         events :  [
            {
                eventType : "CHANGE_ENDURANCE_EVENT",
                ranking : 1,
                amount : -7
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 106,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 159
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 159,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "Your ploy does not work, for the merchant will not allow you to enter his caravan. Suddenly he clicks his fingers and the bodyguard grasps the hilt of his scimitar.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 191,
                content : "You must fight him by turning to "
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 160
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 160,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "Pick a number from the Random Number Table.",
         outcomes :  [
            {
                outcomeType : "RANDOM",
                targetNr : 286,
                intervall : {
                    min : 0,
                    max : 4
                },
                content : "If it is 0–4, you have been seen. Turn to "
            },{
                outcomeType : "RANDOM",
                targetNr : 10,
                intervall : {
                    min : 5,
                    max : 9
                },
                content : "If it is 5–9, they do not spot you and they slowly file away along the far side of the ridge. Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 161
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 161,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Graveyard of the Ancients",
            regionType : "GRAVEYARD",
            description : "The Graveyard of the Ancients is an ancient, mist-shrouded graveyard just North of Holmgard. This place is taboo because of the nameless horrors that inhabit it. No one knows who lies in eternal unrest here but the Evil that lives there is more ancient than the Darklords.",
            imageUrl : "images/flight/regions/graveyardofancients.png"
         },
         content : "As you sit down, the stone serpent slowly moves forward on its plinth. You suddenly break out in a cold sweat and grasp your weapon with trembling fingers in case it should attack. A red forked tongue appears from the head of this strange statue and dips into the bowl of green light above your head. Slowly the tongue re-emerges holding a Golden Key which, to your surprise, it drops into your lap. A panel in the east wall clicks open to reveal an exit. You take the Key and leave as quickly as possible.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 209,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 162
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 162,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Silvermoon Lake",
            regionType : "LAKE",
            description : "The Silvermoon Lake is a ...",
            imageUrl : "images/flight/regions/silvermoonlake.png"
         },
         content : "As you get nearer to the men, you call to them. As they turn to face you, your skin turns cold and your heart pounds, for they are Drakkarim in disguise. Suddenly they charge at you. Forced to the ground, you are tied up with ropes and dragged behind them along a track. They take your Backpack and Weapons, but do not search your cloak or find your Gold Crowns. They cackle menacingly to themselves, and talk at great length of the tortures that await you at their camp.",
         outcomes :  [
            {
                outcomeType : "ABILITY",
                targetNr : 258,
                ability : {
                    abilityType : "MIND_OVER_MATTER",
                    description : "Mastery of this Discipline enables a Kai Lord to move small objects with his powers of concentration."
                },
                content : "If you have the Kai Discipline of Mind Over Matter, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 127,
                content : "If you do not have this skill, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 163
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 163,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Silvermoon Lake",
            regionType : "LAKE",
            description : "The Silvermoon Lake is a ...",
            imageUrl : "images/flight/regions/silvermoonlake.png"
         },
         content : "After nearly half an hour you feel the current getting stronger. Looking out across the surface you can see that you are approaching a whirlpool in the middle of a large river bend. You will surely drown if caught in its current, so you quickly swim towards the right hand river bank and continue your mission on foot, carrying all your equipment.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 321,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 164
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 164,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "Carefully opening the seals on each of the bottles, you sniff at the contents. They all seem to be different types of wine. Suddenly a smaller bottle tucked behind the others catches your eye. Pulling out the glass stopper, you recognize the smell to be that of Alether, a Potion of Strength, which is orange in colour. You may keep this Potion and swallow it before you fight. It will increase your COMBAT SKILL by 2 points for the duration of your fight. Be sure to mark it down on your Action Chart and to strike it off once you have used it.",
         events :  [
            {
                eventType : "ACQUIRE_ITEM_EVENT",
                ranking : 1,
                item : {
                    name : "Potion of Alether",
                    itemType : "POTION",
                    description : "Potion of Alether",
                    weight : "SMALL",
                    imageUrl : "images/flight/items/alether.png"
                }
            },{
                eventType : "ACQUIRE_ITEM_EVENT",
                ranking : 2,
                item : {
                    name : "Potion of Alether",
                    itemType : "POTION",
                    description : "Potion of Alether",
                    weight : "SMALL",
                    imageUrl : "images/flight/items/alether.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 308,
                content : "You now decide to investigate the stable by turning to "
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 165
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 165,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Kings Citadel",
            regionType : "CITADEL",
            description : "The Kings Citadel is the highest law enforcement and paramilitary organization in Holmgard.",
            imageUrl : "images/flight/regions/holmguardcitadel.png"
         },
         content : "You awake in a fever. Images swim before your eyes and then fade completely. The pain in your back is intense and you cry out for relief. You feel a cool, damp cloth placed on your forehead and glimpse the worried face of a young woman. An old man whispers in her ear and then he disappears from view. The girl kneels at your side and comforts you with words of kindness and reassurance, but the light quickly fades and darkness engulfs you once more.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 212,
                content : "Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 166
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 166,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Graveyard of the Ancients",
            regionType : "GRAVEYARD",
            description : "The Graveyard of the Ancients is an ancient, mist-shrouded graveyard just North of Holmgard. This place is taboo because of the nameless horrors that inhabit it. No one knows who lies in eternal unrest here but the Evil that lives there is more ancient than the Darklords.",
            imageUrl : "images/flight/regions/graveyardofancients.png"
         },
         content : "You are in the presence of a great evil. Your mind is being probed by a powerful and timeless being and you must shield yourself. The struggle has begun and your sanity is at stake. It is a long and torturous ordeal, during which you experience many fantastic and terrible apparitions that tempt and appal you. After this you must lose 4 ENDURANCE points and stagger towards the tunnel.",
         events :  [
            {
                eventType : "CHANGE_ENDURANCE_EVENT",
                ranking : 1,
                amount : -4
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 104,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 167
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 167,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "You have been travelling for about a mile when you notice two legs sticking out from behind a large boulder.",
         outcomes :  [
            {
                outcomeType : "ABILITY",
                targetNr : 178,
                ability : {
                    abilityType : "SIXTH_SENSE",
                    description : "This skill may warn a Kai Lord of imminent danger. It may also reveal the true purpose of a stranger or strange object encountered in your adventure."
                },
                content : "If you possess and wish to use the Kai Discipline of Sixth Sense, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 88,
                content : "If you wish to take a closer look, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 264,
                content : "If you would rather avoid meeting their owner and press on into the forest, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 168
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 168,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "You pull yourself to the top of the opulent caravan and nestle among the travelling cases and bags. Night will soon engulf the highway. A chill wind blows from the west and you pull your cloak around yourself to keep warm. You listen to the voices below and you can smell the mouthwatering aroma of spiced meat. It reminds you that you are very hungry and must now take a Meal. The fatigue of your ordeal finally catches up with you and you drift off into a restless sleep.",
         events :  [
            {
                eventType : "CHANGE_RATION_AMOUNT_EVENT",
                ranking : 1,
                amount : -1
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 64,
                content : "Turn to "
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 169
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 169,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Graveyard of the Ancients",
            regionType : "GRAVEYARD",
            description : "The Graveyard of the Ancients is an ancient, mist-shrouded graveyard just North of Holmgard. This place is taboo because of the nameless horrors that inhabit it. No one knows who lies in eternal unrest here but the Evil that lives there is more ancient than the Darklords.",
            imageUrl : "images/flight/regions/graveyardofancients.png"
         },
         content : "As you pass each skull, it slowly turns, as if watching your every move. You are halfway across the room when you hear the sharp crack of bone splitting. Suddenly you see hideous shapes hatching inside the skulls, and stretching their wings. Ten slimy winged creatures attack you, and you must fight them as one enemy.",
         events :  [
            {
                eventType : "COMBAT",
                ranking : 1,
                creature : {
                    name : "Crypt Spawn",
                    combatSkill : 16,
                    endurance : 16,
                    imageUrl : "images/flight/creatures/cryptspawn.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 137,
                content : "If you win the combat, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 170
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 170,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Clearing",
            regionType : "CLEARING",
            description : "You pass through a long, dark tunnel of voerhanging branches that eventually opens out into a large clearing.",
            imageUrl : "images/flight/regions/clearing.png"
         },
         content : "The tunnel is dark and the air is much cooler than outside. You carefully advance with one hand on the tunnel wall to aid your sense of direction. You have been in total darkness for three minutes when you detect the foul smell of decay ahead, similar to rotting meat. If you have a Torch and Tinderbox in your Pack, you may light the Torch to see your way ahead. Suddenly, something heavy drops from the tunnel ceiling onto your back and you fall to your knees.  It is a Burrowcrawler and you must fight it, for it is trying to strangle you with its long slimy tentacles.",
         events :  [
            {
                eventType : "COMBAT",
                ranking : 1,
                creature : {
                    name : "Burrowcrawler",
                    combatSkill : 17,
                    endurance : 7,
                    imageUrl : "images/flight/creatures/burrowcrawler.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 319,
                content : "If you win, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 171
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 171,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "You are at the very edge of the wood when your horse rears up in agony. The Kraan has sunk its claws deep into the horse’s hind legs and is trying to knock you to the ground with its wings. The ghoulish Giak rider squeals with delight as he stabs at you with his spear. You jump to the ground and dash for the trees, leaving the poor dying horse in the clutches of the Kraan.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 303,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 172
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 172,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Silvermoon Lake",
            regionType : "LAKE",
            description : "The Silvermoon Lake is a ...",
            imageUrl : "images/flight/regions/silvermoonlake.png"
         },
         content : "Night falls and you are soon engulfed in darkness. To press on any further would be futile, for you would be sure to lose your way. Tethering your horse to a tree, you pull your green Kai cloak about you and fall into a restless sleep. You are awoken by the sound of troops in the distance. Across the lake you see the black shapes of Drakkarim and a pack of Doomwolves. A Kraan appears from above the trees and lands on the roof of the small wooden shack. It is being ridden by a creature dressed in red robes. The Kraan takes off and begins to fly across the lake to where you are hidden.",
         outcomes :  [
             {
                outcomeType : "ABILITY",
                targetNr : 114,
                ability : {
                    abilityType : "CAMOUFLAGE",
                    description : "This Discipline enables a Kai Lord to blend in with his surroundings. In the countryside, he can hide undetected among trees and rocks and pass close to an enemy without being seen. In a town or city, it enables him to look and sound like a native of that area, and can help him to find shelter or a safe hiding place."
                },
                content : "If you wish to use the Kai Discipline of Camouflage to hide yourself and your horse, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 239,
                content : "If you wish to ride deeper into the forest to escape the Kraan, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 29,
                content : "If you wish to prepare to fight the creature, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 173
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 173,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region: {
            name : "Darkstone Temple",
            regionType : "EVIL_TEMPLE",
            description : "It was only by an unlucky chance you discovered teh secret temple of a sect of evil druids",
            imageUrl : "images/flight/regions/darkstonetemple.png"
         },
         content : "As you reach the door you hear the crash of a giant stone slab as it falls from the ceiling. Turning around, you see that your exit is now blocked.",
         outcomes :  [
            {
                outcomeType : "ITEM",
                targetNr: 158,
                item : {
                    code : "SILVER_KEY",
                    name : "Silver Key",
                    description : "Silver Key",
                    imageUrl : "images/flight/items/.png"
                },
                content : "If you have a Silver Key, you may try to open the door by turning to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 259,
                content : "If you do not possess a Silver Key, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 174
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 174,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Silvermoon Lake",
            regionType : "LAKE",
            description : "The Silvermoon Lake is a ...",
            imageUrl : "images/flight/regions/silvermoonlake.png"
         },
         content : "After nearly an hour of drifting downstream, the water current becomes quite strong and you can see that you are being drawn towards a whirlpool near the centre as the river curves round. You know that if you are caught in the swirling water, you stand very little chance of escaping a watery death. You dive into the muddy river and as you begin to swim towards the shore.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 190,
                content : "Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 175
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 175,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Silvermoon Lake",
            regionType : "LAKE",
            description : "The Silvermoon Lake is a ...",
            imageUrl : "images/flight/regions/silvermoonlake.png"
         },
         content : "Waving your arms at the approaching cavalry, you recognize them to be Border Rangers of the King’s army, tough woodsmen who police the troubled western frontier of the kingdom. Your relief at seeing them soon fades when you realize that they are fleeing from a pack of Doomwolves with snarling Giak riders. Black arrows are dropping all around the rangers, as the vicious Doomwolves get nearer and nearer.",
         outcomes :  [
            {
                outcomeType : "ABILITY",
                targetNr : 182,
                ability : {
                    abilityType : "CAMOUFLAGE",
                    description : "This Discipline enables a Kai Lord to blend in with his surroundings. In the countryside, he can hide undetected among trees and rocks and pass close to an enemy without being seen. In a town or city, it enables him to look and sound like a native of that area, and can help him to find shelter or a safe hiding place."
                },
                content : "If you possess the Kai Discipline of Camouflage, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 41,
                content : "If you wish to take cover and hide, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 116,
                content : "If you wish to make for the other bank, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 176
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 176,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Silvermoon Lake",
            regionType : "LAKE",
            description : "The Silvermoon Lake is a ...",
            imageUrl : "images/flight/regions/silvermoonlake.png"
         },
         content : "You hide behind some thick bushes so that the Doomwolf and its rider will not see your white horse. Luckily it works—the beast lopes past and vanishes down the track that you have just come along.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 253,
                content : "If you wish to attack the remaining Doomwolves and their riders, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 126,
                content : "If you wish to press on deeper into the forest, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 177
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 177,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Boat Crossing",
            regionType : "CITY_OUTSKIRTS",
            description : "The outer fildworks of the city can now be seen.",
            imageUrl : "images/flight/regions/holmguardoutskirts.png"
         },
         content : "You search all of the cupboards in the small cottage but do not find anything of use or value. You decide that you have wasted enough time here and must press on without further delay.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 83,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 178
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 178,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "Your skill enables you to recognize the boots and leggings of a King’s soldier. You can sense that the man is wounded and in need of help.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 88,
                content : "If you wish to aid him, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 264,
                content : "If you would rather leave him here, turn to "
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 179
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 179,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Boat Crossing",
            regionType : "CITY_OUTSKIRTS",
            description : "The outer fildworks of the city can now be seen.",
            imageUrl : "images/flight/regions/holmguardoutskirts.png"
         },
         content : "You have been spotted by the guards who level their crossbows at you.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 318,
                content : "If you wish to raise your hands above your head and walk slowly towards them, turn to "
            },  {
                outcomeType : "DEFAULT",
                targetNr : 51,
                content : "If you wish to run for cover in the trees, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 180
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 180,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Boat Crossing",
            regionType : "CITY_OUTSKIRTS",
            description : "The outer fildworks of the city can now be seen.",
            imageUrl : "images/flight/regions/holmguardoutskirts.png",
         },
         content : "They see you raise your weapon, and they instantly attack you.",
         events :  [
            {
                eventType : "COMBAT",
                ranking : 1,
                creature : {
                    name : "Sergant",
                    combatSkill : 15,
                    endurance : 22,
                    imageUrl : "images/flight/creatures/sergant.png"
                }
            }, {
                eventType : "COMBAT",
                ranking : 2,
                creature : {
                    name : "Soldier",
                    combatSkill : 13,
                    endurance : 20,
                    imageUrl : "images/flight/creatures/soldier.png"
                }
            }, {
                eventType : "COMBAT",
                ranking : 3,
                creature : {
                    name : "Soldier",
                    combatSkill : 12,
                    endurance : 20,
                    imageUrl : "images/flight/creatures/soldier.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 62,
                content : "If you kill all three of them, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 181
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 181,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "Instinctively you duck, and dive to avoid the crossbow bolt. The bandit fires and you feel the sleeve of your jacket tear as the missile grazes past your left arm. You thank the gods for your good fortune and sprint on. None of the other bandits have bows and they soon give up the chase. As you sprint off into the distance, you leave them all far behind. You stop just long enough to strap up your wounded arm and then continue along the road towards the outer defences of the capital.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 288,
                content : "Turn to "
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 182
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 182,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Silvermoon Lake",
            regionType : "LAKE",
            description : "The Silvermoon Lake is a ...",
            imageUrl : "images/flight/regions/silvermoonlake.png"
         },
         content : "Three rangers gallop past the river bank, closely followed by the Giaks on their snarling mounts—the Doomwolves. But your Camouflage skill has saved you from being spotted. The pack of evil Giaks continue on their chase without even glancing at the river.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 174,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 183
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 183,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "The officer orders his men to halt and asks you your business. You tell him who you are, and how the monastery has been destroyed. He is deeply saddened to hear your news. He offers you a horse and asks you to accompany him to Prince Pelathar, the King’s son.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 97,
                content : "If you accept, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 200,
                content : "If you decide to decline his offer, turn to "
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 184
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 184,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "The caravan is out of control and is bumping wildly through the rough ground that borders the highway. With difficulty you eventually steer the frightened horses back onto the road and halt the caravan. A quick search of the interior reveals 40 Gold Crowns, a Sword, and enough Food for 3 Meals. If you wish to keep any of these items, mark them on your Action Chart.",
         events :  [
            {
                eventType : "CHANGE_GOLD_AMOUNT_EVENT",
                ranking : 1,
                amount : 40
            }, {
                eventType : "CHANGE_RATION_AMOUNT_EVENT",
                ranking : 2,
                amount : 3
            }, {
                eventType : "ACQUIRE_ITEM_EVENT",
                ranking : 3,
                item : {
                    name : "Sword",
                    itemType : "WEAPON",
                    description : "Sword",
                    weight : "MEDIUM",
                    imageUrl : "images/flight/items/sword.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 64,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 185
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 185,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "You narrow your eyes and scan the trees for some sign of the hidden archer. Your wait is not a long one, for a moment later a sharp pain tears through your chest and you are thrown back by the force of three arrows. Two of the black shafts have sunk deep into your rib cage, and the third has pierced your thigh. The last thing that you see is the canopy of fern trees above and a large green dragonfly as it settles on your belt buckle. Your life and your mission end here.",
         events :  [
            {
                eventType : "MISSION_FAILED_EVENT",
                ranking : 1
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 186
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 186,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "The Kakarmi disappear into the dense undergrowth and you soon find yourself lost. After nearly two hours of walking you hear the sound of running water. You decide to investigate a little closer.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 106,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 187
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 187,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "Two furry faces appear over the top of the trunk. Both pairs of eyes stare at your weapon and the two creatures let out a shriek of fright. Leaping from the trunk, they disappear into the forest.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 186,
                content : "If you wish to follow them, turn to"
            },  {
                outcomeType : "DEFAULT",
                targetNr : 228,
                content : "If you wish to let them go and continue, turn to"
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 188
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 188,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "You can see the shadow of the Kraan getting larger all around you. It suddenly strikes, pitching you forward onto your face with the power of its attack. You have been wounded in both arms. Lose 3 ENDURANCE points and run to the trees.",
         events :  [
            {
                eventType : "CHANGE_ENDURANCE_EVENT",
                ranking : 1,
                amount : -3
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 303,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 189
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 189,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "You thank your Kai training and your quick thinking, for that bog could have proved as deadly as any Drakkarim or Kraan. You are worried about losing time, and push on further into the trees towards the south. Ahead of you, you see a wide path that also leads south.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 118,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 190
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 190,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Silvermoon Lake",
            regionType : "LAKE",
            description : "The Silvermoon Lake is a ...",
            imageUrl : "images/flight/regions/silvermoonlake.png"
         },
         content : "You walk for three miles along the water’s edge until you chance upon a wrecked river barge. It appears to have served as shelter for someone, as you can see a bed and some cooking utensils through a hole in the deck.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 20,
                content : "If you wish to search the barge, turn to "
            },  {
                outcomeType : "DEFAULT",
                targetNr : 273,
                content : "If you wish to press on, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 191
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 191,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         content : "The bodyguard unsheathes a large scimitar and strikes at your head.",
         events :  [
            {
                eventType : "COMBAT",
                ranking : 1,
                creature : {
                    name : "Bodyguard",
                    combatSkill : 11,
                    endurance : 21,
                    imageUrl : "images/flight/creatures/bodyguard.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 24,
                content : "If you win, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 192
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 192,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "You see the razor-fanged mouth of a Doomwolf and hear the hideous cries of the Giaks. Two of them are coming straight for you. You are saved from certain death when your horse jumps at the approaching beasts, knocking them both to the ground. You lash out at the Giak and open a large wound in his head ... and then suddenly, as if by a miracle, you’re through and racing on down the highway, clear of the rest of the pack. But a shadow follows you. It is a Kraan and it has started to dive. Its target is you.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 171,
                content : "If you veer off the highway towards the cover of the trees, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 120,
                content : "If you press on regardless of the Kraan and gallop flat out down the highway, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 193
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 193,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Silvermoon Lake",
            regionType : "LAKE",
            description : "The Silvermoon Lake is a ...",
            imageUrl : "images/flight/regions/silvermoonlake.png"
         },
         content : "The beast and its rider lie dead. You notice a Scroll tucked into the Giak’s belt. You may take this if you wish, but remember to mark it on your Action Chart. The other Doomwolves are charging along the path towards you.",
         events :  [
            {
                eventType : "ACQUIRE_ITEM_EVENT",
                ranking : 1,
                item : {
                    name : "Giak Scroll",
                    itemType : "SCROLL",
                    description : "Scroll",
                    weight : "SMALL",
                    imageUrl : "images/flight/items/giakscroll.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 253,
                content : "If you wish to fight them, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 126,
                content : "If you wish to escape into the woods, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 194
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 194,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "You sprint towards the wagon. People are running everywhere in panic as the Kraan make their attack, carrying their poor victims off into the darkening sky. A large Kraan is hovering above the wagon and three snarling Giaks drop from its back onto the startled horses. You must fight them or leave the wagon and run to the safety of a nearby farmhouse.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 208,
                content : "If you wish to fight the Giaks, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 148,
                content : "If you wish to run to the farmhouse, turn to "
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 195
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 195,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "Wiping the bear’s blood from your weapon, you notice the mouth of a cave hidden behind the rock from which the bear attacked.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 59,
                content : "If you wish to investigate this cave further, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 106,
                content : "If you wish to press on, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 196
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 196,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Kings Citadel",
            regionType : "CITADEL",
            description : "The Kings Citadel is the highest law enforcement and paramilitary organization in Holmgard.",
            imageUrl : "images/flight/regions/holmguardcitadel.png"
         },
         content : "You follow the man into a small library off the main hall. He pushes one of the many books on the shelves which line all four walls, and you hear a metallic click. One section of the bookcase slowly slides back to reveal a hidden passage.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 332,
                content : "If you wish to follow the man into the passage, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 144,
                content : "If you do not want to enter the dark corridor, leave the guildhall and return to the street. Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 197
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 197,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Silvermoon Lake",
            regionType : "LAKE",
            description : "The Silvermoon Lake is a ...",
            imageUrl : "images/flight/regions/silvermoonlake.png"
         },
         content : "The Drakkar lies dead at the bottom of the ferry. He has a Sword and 6 Gold Crowns which you may keep if you wish. You push the body into the water where it floats for a few seconds before disappearing into the icy depths. Grabbing the pole, you steer to the other side of the lake and abandon the ferry.",
         events :  [
            {
                eventType : "ACQUIRE_ITEM_EVENT",
                ranking : 1,
                item : {
                    name : "Sword",
                    itemType : "WEAPON",
                    description : "Sword",
                    weight : "MEDIUM",
                    imageUrl : "images/flight/items/sword.png"
                }
            }, {
                eventType : "CHANGE_GOLD_AMOUNT_EVENT",
                ranking : 2,
                amount : 6
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 172,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 198
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 198,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Holmgard",
            regionType : "CITY",
            description : "Holmgard is the capital of Sommerlund and is a seaport on the Holmgulf. It is located near the Graveyard of the Ancients. The city is enclosed by grey-white walls two hundred feet in height whose gatehouses are 100 yards long. At the center of the city is the Citadel of the King.",
            imageUrl : "images/flight/regions/holmguard.png"
         },
         content : "You can sense that there is someone else behind the screen. There is a lingering aura of wickedness around this shop. Be on your guard—something is wrong here.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 7,
                content : "If you wish to return to the street, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 152,
                content : "If you wish to examine the goods in the glass counter, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 199
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 199,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "Most of the cupboards and drawers are empty. Whoever lived here took nearly everything they owned with them, but you do manage to scrape together enough fruit in the cellar for one Meal. You may mark this on your Action Chart.",
         events :  [
            {
                eventType : "CHANGE_RATION_AMOUNT_EVENT",
                ranking : 1,
                amount : 6
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 81,
                content : "Turn to "
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 200
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 200,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "Night is starting to close in. The shadows of the forest are growing longer and darker. Just as you are about to stop and rest, you see through the trees a line of people moving south along a wide highway. Moving closer, you notice a large merchant’s caravan in the centre of the dusty turnpike. It is drawn by six large horses and is moving much faster than any of the other traffic. This could be your chance to reach the capital as quickly as possible.",
         outcomes :  [
            {
                outcomeType : "ABILITY",
                targetNr : 168,
                ability : {
                    abilityType : "CAMOUFLAGE",
                    description : "This Discipline enables a Kai Lord to blend in with his surroundings. In the countryside, he can hide undetected among trees and rocks and pass close to an enemy without being seen. In a town or city, it enables him to look and sound like a native of that area, and can help him to find shelter or a safe hiding place."
                },
                content : "If you wish to use the Kai Discipline of Camouflage to hide in among the packing cases strapped to the roof, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 78,
                content : "If you wish to jump onto the caravan, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 201
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 201,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "You follow the rough track for nearly an hour when you notice ahead of you another wider path branching off towards the south.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 238,
                content : "If you wish to turn south along the new path, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 201,
                content : "But if you wish to head east, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 130,
                content : "Or if you wish to go west, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 202
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 202,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Boat Crossing",
            regionType : "CITY_OUTSKIRTS",
            description : "The outer fildworks of the city can now be seen.",
            imageUrl : "images/flight/regions/holmguardoutskirts.png"
         },
         content : "Urging your horse forward, you gallop down the long stretch of highway towards the capital. After only a few minutes your horse suddenly slows and finally limps to a halt. You dismount and examine its raised right foreleg. You curse your ill luck, for you see that it has thrown a shoe and injured its hoof quite badly. You will have to leave him here and proceed on foot as quickly as you can.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 58,
                content : "Turn to "
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 203
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 203,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Holmgard",
            regionType : "CITY",
            description : "Holmgard is the capital of Sommerlund and is a seaport on the Holmgulf. It is located near the Graveyard of the Ancients. The city is enclosed by grey-white walls two hundred feet in height whose gatehouses are 100 yards long. At the center of the city is the Citadel of the King.",
            imageUrl : "images/flight/regions/holmguard.png"
         },
         content : "You suddenly feel a searing pain shoot through your chest as something explodes against you in a shower of red sparks. You lose 10 ENDURANCE points. Through the smoke, the Sage is preparing to throw more explosives at you.",
         events :  [
            {
                eventType : "CHANGE_ENDURANCE_EVENT",
                ranking : 1,
                amount : 10
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 80,
                content : "If you have 10 or more ENDURANCE points left, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 344,
                content : "If you now have less than 10 ENDURANCE points, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 204
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 204,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "After an hour of walking you arrive at a junction. The path continues south and another path joins it from the west. You realize that the west path will lead you back to the marsh, so you continue southwards.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 111,
                content : "Turn to "
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 205
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 205,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Boat Crossing",
            regionType : "CITY_OUTSKIRTS",
            description : "The outer fildworks of the city can now be seen.",
            imageUrl : "images/flight/regions/holmguardoutskirts.png",
         },
         content : "Their leader picks up your discarded Equipment and ushers you along the road ahead. (You must now erase all Weapons and Backpack Items from your Action Chart.) An evil grin spreads across the face of the other two men, and you suddenly realize that they are not soldiers after all. You make a break for it and run away from there, sprinting towards the distant capital. Behind you, the ominous click of a crossbow being primed sends a shiver down your spine. Pick a number from the Random Number Table.",
         events :  [
            {
                eventType : "DROP_ALL_WEAPONS_EVENT",
                ranking : 1
            }, {
                eventType : "DROP_BACKPACK_EVENT",
                ranking : 2
            }
         ],
         outcomes :  [
           {
                outcomeType : "RANDOM",
                targetNr : 181,
                intervall : {
                    min : 0,
                    max : 4
                },
                content : "If the number you have picked is 0–4, turn to "
            }, {
                outcomeType : "RANDOM",
                targetNr : 145,
                intervall : {
                    min : 5,
                    max : 9
                },
                content : "If the number is 5–9, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 206
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 206,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         content : "The path soon joins a highway where a signpost indicates Toran to the north and Holmgard to the south. You turn south towards the capital.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 224,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 207
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 207,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
          region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "The track soon reaches a larger road which crosses the stream via a stone bridge. A signpost at the bridge points north to Toran and south to Holmgard. The road itself is jammed with people moving south, some pushing their possessions along on handcarts. You join the refugee column and head towards the capital.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 30,
                content : ""
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 208
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 208,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "The ghoulish creatures thrust their spears at you and attack. Fight these creatures as a single enemy.",
         events :  [
            {
                eventType : "COMBAT",
                ranking : 1,
                creature : {
                    name : "Giak",
                    combatSkill : 12,
                    endurance : 12,
                    imageUrl : "images/flight/creatures/giak.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 148,
                content : "If you win, you can run to the safety of the farmhouse by turning to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 209
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 209,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Graveyard of the Ancients",
            regionType : "GRAVEYARD",
            description : "The Graveyard of the Ancients is an ancient, mist-shrouded graveyard just North of Holmgard. This place is taboo because of the nameless horrors that inhabit it. No one knows who lies in eternal unrest here but the Evil that lives there is more ancient than the Darklords.",
            imageUrl : "images/flight/regions/graveyardofancients.png"
         },
         content : "You see ahead a corridor sloping upwards, and as you reach the top of this slope, a stone portal slides across to reveal another passage ahead. You step through the opening which then quickly closes with a crunch.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 23,
                content : "Turn to "
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 210
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 210,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Kings Citadel",
            regionType : "CITADEL",
            description : "The Kings Citadel is the highest law enforcement and paramilitary organization in Holmgard.",
            imageUrl : "images/flight/regions/holmguardcitadel.png"
         },
         content : "Just inside the door, you are stopped by a journeyman of the Guildhall and asked to explain your intrusion. You calmly inform him of your urgent message for the King, and he hurries you into the Guildmaster’s chambers. A distinguished old man in deep purple robes turns to greet you and listens to your story. Taking you by the arm, he leads you into an adjoining library and closes the door. Pressing one of the many thousands of books, he releases a secret panel in the wall and beckons you to follow him.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 332,
                content : "If you wish to follow him into the dark passage, turn to "
            },  {
                outcomeType : "DEFAULT",
                targetNr : 37,
                content : "If you are not completely happy about this man and wish to leave the Guildhall, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 211
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 211,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         content : "You walk along a dimly lit corridor which opens out into a large square room, with an oak door in the far wall. ",
         outcomes :  [
            {
                outcomeType : "ABILITY",
                targetNr : 244,
                ability : {
                    abilityType : "SIXTH_SENSE",
                    description : "This skill may warn a Kai Lord of imminent danger. It may also reveal the true purpose of a stranger or strange object encountered in your adventure."
                },
                content : "If you possess the Kai Discipline of Sixth Sense turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 173,
                content : "If you wish to walk across to the door, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 106,
                content : "If you would prefer to return to the surface and continue your journey, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 212
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 212,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Kings Citadel",
            regionType : "CITADEL",
            description : "The Kings Citadel is the highest law enforcement and paramilitary organization in Holmgard.",
            imageUrl : "images/flight/regions/holmguardcitadel.png"
         },
         content : "When you awake, the pain is but a memory. Restore all lost ENDURANCE points to your original score. A tall man dressed in white robes stands before you, a bowl of herbs in his hands. Placing the leaves into a kettle of boiling water, he then turns to greet you. ‘You have passed close to death and have seen his face, Kai Lord, but the Grey One has not claimed you for his flock. You are healed in body but I sense that you are wounded in spirit. What is it that troubles you so?’ You recognize the man to be one of the King’s senior physicians, for the gold embroidered emblem of a dove upon his sleeve is the sign of his respected vocation. You tell the aged cleric of the events at the monastery and of your perilous journey to the King. Raising you gently from the bed by your arm, he bids you follow him. You notice that you are in a lavishly decorated room which leads out through a long corridor lined with tapestries. It slowly dawns on you just where you are. This is the citadel of Holmgard and you are about to meet the King.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 350,
                content : "Turn to "
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 213
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 213,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "You have been trudging through the forest for nearly two hours. The nagging fear that you are lost begins to seem a reality. Apart from the occasional cry of a Kraan in the far distance, you have seen or heard no evidence that the enemy is in this part of the forest. As you descend a rocky hillock, you see something unusual in the tangled woods ahead.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 331,
                content : "Turn to "
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 214
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 214,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "The path gradually narrows until it disappears completely into a mass of dense vegetation. You cannot go any further on this route and therefore you must return to the clearing.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 125,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 215
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 215,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "You emerge into a small clearing. In the centre you see the skeletal remains of a large animal. To the south a narrow track leads off into the distance.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 346,
                content : "If you wish to examine the skeleton, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 14,
                content : "If you would rather press on, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 216
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 216,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Dragon Bridge",
            regionType : "BRIDGE",
            description : "The Dragon Bridge connects the northern and southern part of Summerlund.",
            imageUrl : "images/flight/regions/dragonbridge.png"
         },
         content : "Placing one hand on his forehead and the other on his wounded arm, you feel the warmth of your healing powers leave your body and give strength to the injured man. He tells you his name is Trimis and he is a soldier in Prince Pelathar’s army. The Prince and his troops are engaged in battle to the south, where a large force of the Darklords’ creatures are attacking the bridge of Alema. During the fight, he had been snatched into the air by a Kraan, and dropped into the forest. You make the soldier as comfortable as possible before continuing on your mission.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 264,
                content : "If you would rather press on, turn to "
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 217
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 217,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Kings Citadel",
            regionType : "CITADEL",
            description : "The Kings Citadel is the highest law enforcement and paramilitary organization in Holmgard.",
            imageUrl : "images/flight/regions/holmguardcitadel.png"
         },
         content : "You quickly escape from the madman and dodge along a dark alleyway where the houses are small and cramped together. At the very end is a green door with a sign above it that says: Herbalis",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 91,
                content : "If you wish to enter, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 7,
                content : "If you wish to wait until you are sure the madman has disappeared and then return to the main street, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 218
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 218,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "Your senses reveal that more than just horses are heading towards you. You can just make out the very high shrieks of Giak war-cries in the distance. By the number of cries and curses you estimate that there are over a dozen Giaks, and probably Doomwolves as well. You decide that advertising your existence is perhaps not quite such a good idea after all!",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 75,
                content : "Turn to"
            }
         ]
    },    {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 219
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 219,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Holmgard",
            regionType : "CITY",
            description : "Holmgard is the capital of Sommerlund and is a seaport on the Holmgulf. It is located near the Graveyard of the Ancients. The city is enclosed by grey-white walls two hundred feet in height whose gatehouses are 100 yards long. At the center of the city is the Citadel of the King.",
            imageUrl : "images/flight/regions/holmguard.png"
         },
         content : "All that remains of you now is embedded five feet into the stairs on which you were standing, beneath a vast granite block. Your mission and your life end here. ",
         events :  [
            {
                eventType : "MISSION_FAILED_EVENT",
                ranking : 1
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 220
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 220,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
          region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         events : [
             {
                eventType : "COMBAT",
                ranking : 1,
                creature : {
                    name : "Bodyguard",
                    combatSkill : 11,
                    endurance : 21,
                    imageUrl : "images/flight/creatures/bodyguard.png"
                }
            }
         ],
         content : "The bodyguard unsheathes a scimitar and lunges for your head. ",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 24,
                content : "If you win, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 234,
                content : "If you wish to evade combat at any time during the fight, you can jump from the speeding caravan by turning to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 221
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 221,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Boat Crossing",
            regionType : "CITY_OUTSKIRTS",
            description : "The outer fildworks of the city can now be seen.",
            imageUrl : "images/flight/regions/holmguardoutskirts.png"
         },
         content : "Cautiously, you approach the base of the log wall. The tree trunks are rough-hewn and afford plenty of footholds for your climb. As you reach the top of the wall, you come face to face with a crossbow. The soldier holding it in your face motions for you to descend a wooden ladder to the ground. You do not argue with him. Slowly you descend the ladder.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 318,
                content : "Turn to"
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 222
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 222,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "As you go on you discover a forest path that divides at the point you join it.",
         outcomes :  [
             {
                outcomeType : "ABILITY",
                targetNr : 67,
                ability : {
                    abilityType : "TRACKING",
                    description : "This skill enables a Kai Lord to make the correct choice of a path in the wild, to discover the location of a person or object in a town or city and to read the secrets of footprints or tracks."
                },
                content : "If you wish to use your Kai Discipline of Tracking, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 140,
                content : "If you wish to take the south fork, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 252,
                content : "If you wish to take the east fork, turn to "
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 223
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 223,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Riverbank",
            regionType : "RIVER_BANK",
            description : "Peering over the steep undercut of the riverbank, you can see a tanble of driftwood along the waters edge.",
            imageUrl : "images/flight/regions/riverbank.png"
         },
         content : "After quite a struggle, you manage to free the heavy trunk from the river bank. Gathering your equipment in a bundle, you stow it on top of the log and then slowly wade out into the river. The current soon takes you and you drift slowly downstream. After twenty minutes you hear the sound of horses along the left bank. ",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 75,
                content : "If you wish to hide behind the log, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 175,
                content : "If you wish to climb onto the log and prepare to catch the riders’ attention, then turn to "
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 224
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 224,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Boat Crossing",
            regionType : "CITY_OUTSKIRTS",
            description : "The outer fildworks of the city can now be seen.",
            imageUrl : "images/flight/regions/holmguardoutskirts.png"
         },
         content : "You have ridden several miles and have seen no sign of refugees or of the enemy. You race on towards a high ridge in the middle distance. You should be able to see the capital from there. As you reach the peak, the sight that meets you on the far side is one of hope—but there is still one challenge you know you have to face.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 153,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 225
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 225,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "You recognize the language to be that of the Kakarmi, an intelligent race of forest animals that live in, and care for the forests of Sommerlund. You have nothing to fear from these creatures as they are very timid and gentle in their behaviour. Using your skill of Animal Kinship, you call to them in their strange native tongue.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 187,
                content : "If you say ‘Do not be afraid, I am a friend,’ turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 39,
                content : "If you say ‘I am a Kai Lord. I wish you no harm. I must talk with you,’ turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 226
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 226,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "At first the descent is quite easy, but you soon find it difficult to see clearly and your legs feel very weak. The ‘Sleeptooth’ scratches are affecting you, and suddenly you pitch forward and slip head-first into darkness.",
         outcomes :  [
            {
                outcomeType : "RANDOM",
                targetNr : 277,
                intervall : {
                    min : 0,
                    max : 4
                },
                content : "If the number you have picked is 0–4, turn to"
            }, {
                outcomeType : "RANDOM",
                targetNr : 338,
                intervall : {
                    min : 5,
                    max : 9
                },
                content : "If the number is 5–9, turn to"
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 227
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 227,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Yellow Marsh",
            regionType : "MARSH",
            description : "You soon realize that you are walking deeper into a wooded marsh.",
            imageUrl : "images/flight/regions/yellowmarch.png"
         },
         content : "You are now up to your waist in slimy water. The air is thick with small insects that sting your face and clog your nose. Something wraps itself around your leg. It is a Marshviper and you must fight it.",
         events :  [
            {
                eventType : "COMBAT",
                ranking : 1,
                creature : {
                    name : "Marshviper",
                    combatSkill : 13,
                    endurance : 6,
                    imageUrl : "images/flight/creatures/marshviper.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 271,
                content : "If you lose any ENDURANCE points in the combat, turn to "
            },  {
                outcomeType : "DEFAULT",
                targetNr : 348,
                content : "If you kill it without losing any ENDURANCE points, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 228
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 228,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
          region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "The path continues eastwards but soon disappears into thick undergrowth.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 140,
                content : "If you continue east, cutting through the vegetation with your weapon, turn to "
            },  {
                outcomeType : "DEFAULT",
                targetNr : 215,
                content : "If you head south to where the bushes are less dense and then press on through the forest, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 229
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 229,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
          region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "The Kraan hovers above you, raising dust with the beat of its huge black wings. The dust gets into your eyes and nose, and you start to cough. Now the beast attacks. If you win you have a choice:",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 267,
                content : "Will you search the body by turning to "
            },  {
                outcomeType : "DEFAULT",
                targetNr : 125,
                content : "Or will you continue along the east path by turning to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 230
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 230,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Boat Crossing",
            regionType : "CITY_OUTSKIRTS",
            description : "The outer fildworks of the city can now be seen.",
            imageUrl : "images/flight/regions/holmguardoutskirts.png"
         },
         content : "In the far distance, you can make out the silhouette of soldiers on barges that are strung out in a line across the river. You can hear the low growls of Doomwolves returning along the opposite bank. For once you throw caution to the wind and sprint along the river bank towards the barges in the distance.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 179,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 231
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 231,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Holmgard",
            regionType : "CITY",
            description : "Holmgard is the capital of Sommerlund and is a seaport on the Holmgulf. It is located near the Graveyard of the Ancients. The city is enclosed by grey-white walls two hundred feet in height whose gatehouses are 100 yards long. At the center of the city is the Citadel of the King.",
            imageUrl : "images/flight/regions/holmguard.png"
         },
         content : "You are about to ask the price of the potions when the bamboo screen crashes down and a young man leaps at you. He has a long curved dagger in his hand. He is upon you and you must fight for your life.",
         events :  [
            {
                eventType : "COMBAT",
                ranking : 1,
                creature : {
                    name : "Robber",
                    combatSkill : 13,
                    endurance : 20,
                    imageUrl : "images/flight/creatures/robber.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 94,
                content : "If you kill him within 4 rounds of combat, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 203,
                content : "If you are still fighting after 4 rounds of combat, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 7,
                content : "You may evade more fighting after 2 rounds of combat by dashing through the front door. If you wish to do this, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 232
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 232,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Boat Crossing",
            regionType : "CITY_OUTSKIRTS",
            description : "The outer fildworks of the city can now be seen.",
            imageUrl : "images/flight/regions/holmguardoutskirts.png",
         },
         content : "The rough-looking leader approaches you and says, ‘Our needs are simple, kind sir. Your money or your life!’",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 180,
                content : "If you wish to fight them, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 22,
                content : "If you wish to run, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 233
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 233,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "After nearly an hour, you catch up with the horse and succeed in calming him down. You are now north of the cabin, but you are confident of finding your way back. Mounting the horse, you ride back past the cabin, and press on towards the south once again.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 206,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 234
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 234,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "You jump clear of the speeding caravan but land very badly and break your ankle. The pain is terrible and you soon lose consciousness. Unfortunately you never wake up, but it may be of interest to you that your head is now adorning the saddle of a Kraan. Your life and your mission end here.",
         events :  [
            {
                eventType : "MISSION_FAILED_EVENT",
                ranking : 1
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 235
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 235,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         content : "The Prince’s horse is indeed a magnificent animal, fast and sure of foot. You gallop along the twisting track as if it were a straight highway, until the noise of battle has disappeared far behind you. You are hungry and must eat a Meal during your ride. After several miles, the path stops abruptly at a junction. There is a signpost, but it has been hacked down.",
         events :  [
            {
                eventType : "CHANGE_RATION_AMOUNT_EVENT",
                ranking : 1,
                amount : -1
            }
         ],
         outcomes :  [
            {
                outcomeType : "ABILITY",
                targetNr : 254,
                ability : {
                    abilityType : "TRACKING",
                    description : "This skill enables a Kai Lord to make the correct choice of a path in the wild, to discover the location of a person or object in a town or city and to read the secrets of footprints or tracks."
                },
                content : "If you wish to use your Kai Discipline of Tracking, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 32,
                content : "If you wish to turn left, go to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 146,
                content : "If you wish to turn right, go to "
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 236
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 236,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Graveyard of the Ancients",
            regionType : "GRAVEYARD",
            description : "The Graveyard of the Ancients is an ancient, mist-shrouded graveyard just North of Holmgard. This place is taboo because of the nameless horrors that inhabit it. No one knows who lies in eternal unrest here but the Evil that lives there is more ancient than the Darklords.",
            imageUrl : "images/flight/regions/graveyardofancients.png"
         },
         content : "The Gem hovers above the mouth of the skeleton king, glowing a fierce red. Suddenly, an explosion of searing crimson flame lashes upwards from the sarcophagus, destroying the Gem completely. You are thrown against the far wall and knocked unconscious. When you awake, the chamber is completely empty. The skeleton king and the sarcophagus have vanished. You have lost 6 ENDURANCE points, and your initial COMBAT SKILL is reduced by 1 point for the rest of your life. You carefully get to your feet and stagger towards the tunnel.",
         events :  [
            {
                eventType : "CHANGE_ENDURANCE_EVENT",
                ranking : 1,
                amount : -6
            }, {
                eventType : "CHANGE_COMBAT_SKILL_EVENT",
                ranking : 2,
                amount : -1
            }, {
                eventType : "DROP_ALL_ITEMS_EVENT",
                ranking : 3
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 104,
                content : "Turn to "
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 237
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 237,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "You make full use of your Kai Discipline and quickly burrow deep into the loose earth of the wooded hillside. Covering yourself with your cloak, you pull a loose branch across your hastily dug shelter. Pick a number from the Random Number Table.",
         outcomes :  [
            {
                outcomeType : "RANDOM",
                targetNr : 265,
                intervall : {
                    min : 0,
                    max : 4
                },
                content : "If you have picked a number 0–4, then you have passed undetected. Turn to "
            }, {
                outcomeType : "RANDOM",
                targetNr : 72,
                intervall : {
                    min : 5,
                    max : 9
                },
                content : "If you have picked a number 5–9, then you are not so lucky! Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 238
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 238,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
          region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "he path meanders between several small, wooded hills and eventually leads to a ruined log cabin. It seems that it had burnt down not so long ago, for the ashes are still warm and a haze of smoke still lingers. You sense possible danger here.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 42,
                content : "You may leave by the south route by turning to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 68,
                content : "Or you may take the north track by turning to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 239
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 239,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "As you push on into the forest, you hear the wings of the Kraan pass above the trees and disappear northwards. You ride on for nearly an hour until you come to a clearing. On the far side is a track that leads off to the south.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 34,
                content : "If you wish to enter the clearing and take the south exit, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 118,
                content : "If you would rather skirt the edge of the clearing and pick up the track further on, turn to "
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 240
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 240,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
          region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "The path leads along a ridge of wooded hillocks and changes direction towards the east.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 79,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 241
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 241,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Ruins of Raumas",
            regionType : "TEMPLE_RUIN",
            description : "Edging nearer, you soon make out a clearing that you recognize to be the site of the ruins of Raumas.",
            imageUrl : "images/flight/regions/runinsofraumas.png"
         },
         content : "The wizard heeds your cry and spins around just in time to loose a searing bolt of energy at the Giak. The creature’s head disintegrates in flames and its twitching body falls in a heap at the foot of the pillar. The Giak officer sees you and shouts, ‘Ogot...Ogot!’ to his cowering troops, who quickly run away from the ruins to the safety of the forest beyond.The young wizard wipes his brow, and walks towards you, his hand extended in gratitude and friendship.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 237,
                content : "Turn to"
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 242
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 242,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         content : "The lid of the sarcophagus slips to the floor with a dull crunch. You are looking at the remains of an ancient king, who lies still surrounded by his treasure. An ornate crown is still in position on his skull. The jaw of the skeleton is wide open and the darkness of the mouth seems strangely bottomless. A distant rumbling can now be heard from deep in the earth.",
         outcomes :  [
             {
                outcomeType : "ABILITY",
                targetNr : 166,
                ability : {
                    abilityType : "MINDSHIELD",
                    description : "The Darklords and many of the evil creatures in their command have the ability to attack you using their Mindforce. The Kai Discipline of Mindshield prevents you from losing any ENDURANCE points when subjected to this form of attack."
                },
                content : "If you have the Kai Discipline of Mindshield, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 9,
                content : "If you do not, turn to "
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 243
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 243,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "Hurrying through the forest, you stumble and fall down a steep slope which drops you in a heap on a hidden path below. On the path is a dead body. It is a Giak, a spiteful and ghoulish servant of the Darklords. Many centuries ago, their ancestors were used by the Darklords to build for them the infernal city of Helgedad, which lies in the volcanic wastelands beyond the Durncrag range of mountains. The construction of the city was a long and torturous nightmare, and only the strongest of the Giaks survived the heat and poisonous atmospheres of Helgedad. This creature that lies before you is a descendant of these Giak slaves. It has been killed by a sword blow to its head, and by its side lies a Mace. You may take this Weapon if you wish.",
         events :  [
            {
                eventType : "ACQUIRE_ITEM_EVENT",
                ranking : 1,
                item : {
                    name : "Mace",
                    itemType : "WEAPON",
                    description : "A Mace is a",
                    weight : "MEDIUM",
                    imageUrl : "images/flight/items/mace.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 97,
                content : "Continue along the hidden path by turning to "
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 244
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 244,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Graveyard of the Ancients",
            regionType : "GRAVEYARD",
            description : "The Graveyard of the Ancients is an ancient, mist-shrouded graveyard just North of Holmgard. This place is taboo because of the nameless horrors that inhabit it. No one knows who lies in eternal unrest here but the Evil that lives there is more ancient than the Darklords.",
            imageUrl : "images/flight/regions/graveyardofancients.png"
         },
         content : "Your senses tell you that you are not alone. You are in very great danger. Return to the surface as quickly as you can.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 93,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 245
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 245,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Silvermoon Lake",
            regionType : "LAKE",
            description : "The Silvermoon Lake is a ...",
            imageUrl : "images/flight/regions/silvermoonlake.png"
         },
         content : "Arrows hit the water above you, and drop harmlessly past as you swim beneath the surface towards the opposite bank. Quickly you wade out of the river and dash for the trees. You are now out of range of the Giaks, who remount their Doomwolves and continue their chase.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 190,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 246
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 246,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Silvermoon Lake",
            regionType : "LAKE",
            description : "The Silvermoon Lake is a ...",
            imageUrl : "images/flight/regions/silvermoonlake.png"
         },
         content : "When the ferry reaches the middle of the lake, the man stops rowing and stands up. He laughs menacingly and pulls back the hood of his cloak to reveal himself. He is a Drakkar and you must fight him.",
         events :  [
             {
                eventType : "COMBAT",
                ranking : 1,
                creature : {
                    name : "Drakkar",
                    combatSkill : 15,
                    endurance : 23,
                    imageUrl : "images/flight/creatures/drakkar.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 197,
                content : "If you win, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 247
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 247,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "The merchant looks angry. He calls to his bodyguard. You must think of something quickly.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 159,
                content : "If you decide to offer him something of greater value that you have in your Backpack, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 220,
                content : "If you prepare to fight the bodyguard, turn to"
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 248
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 248,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
          region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "You reach the base of the hill and hurry into the forest. After only a few minutes you discover an old forest track.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 44,
                content : "If you wish to follow this track north, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 300,
                content : "If you wish to follow this track east, turn to"
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 249
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 249,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Graveyard of the Ancients",
            regionType : "GRAVEYARD",
            description : "The Graveyard of the Ancients is an ancient, mist-shrouded graveyard just North of Holmgard. This place is taboo because of the nameless horrors that inhabit it. No one knows who lies in eternal unrest here but the Evil that lives there is more ancient than the Darklords.",
            imageUrl : "images/flight/regions/graveyardofancients.png"
         },
         content : "You descend a flight of stone stairs that lead to a large chamber. A macabre sight awaits you. Directly opposite, across the large stone room, is an ornate archway with a corridor leading into the darkness beyond. The strange green light radiates from two lines of skulls each resting on a stone plinth. They face each other to form an eerie walkway across the room.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 169,
                content : "If you wish to walk across the room to the archway, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 107,
                content : "If you wish to attack the skulls, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 250
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 250,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "Leaping from the top of the trunk, you land in front of two small furry creatures. You recognize that they are Kakarmi, an intelligent race of animals that inhabit and tend the forests of Sommerlund. Before you can apologize for your dramatic entrance, the frightened little creatures scurry off into the forest.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 186,
                content : "If you wish to follow them, turn to "
            }, {
                outcomeType : "DEFAULT",
                targetNr : 228,
                content : "If you wish to continue, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 251
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 251,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "You are lucky, they do not seem to have spotted you. They slowly move on and have soon disappeared along the far side of the ridge. You continue your run.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 10,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 252
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 252,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Clearing",
            regionType : "CLEARING",
            description : "You pass through a long, dark tunnel of voerhanging branches that eventually opens out into a large clearing.",
            imageUrl : "images/flight/regions/clearing.png"
         },
         content : "In the centre of a small clearing you see a group of humans talking excitedly and gesturing wildly with their hands. There are two children, three men, and a woman. Their belongings are wrapped in bundles which they carry slung over their shoulders. Their clothes look well made and expensive but they are dirty and torn.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 155,
                content : "If you wish to approach them and ask who they are, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 67,
                content : "If you wish to avoid them and continue onwards on your mission, turn to"
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 253
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 253,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         content : "The Doomwolves are soon on you and you must fight them one at a time.",
         region : {
            name : "Silvermoon Lake",
            regionType : "LAKE",
            description : "The Silvermoon Lake is a ...",
            imageUrl : "images/flight/regions/silvermoonlake.png"
         },
         events :  [
            {
                eventType : "COMBAT",
                ranking : 1,
                creature : {
                    name : "Doomwolf",
                    combatSkill : 14,
                    endurance : 22,
                    imageUrl : "images/flight/creatures/doomwolf.png"
                }
            },{
                eventType : "COMBAT",
                ranking : 2,
                creature : {
                    name : "Doomwolf",
                    combatSkill : 14,
                    endurance : 22,
                    imageUrl : "images/flight/creatures/doomwolf.png"
                }
            },{
                eventType : "COMBAT",
                ranking : 3,
                creature : {
                    name : "Doomwolf",
                    combatSkill : 14,
                    endurance : 22,
                    imageUrl : "images/flight/creatures/doomwolf.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 278,
                content : "If you kill them all in battle, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 254
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 254,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "Your Tracking ability tells you that several trails from the right path lead off in the direction of the left path. They have been made by large wolves. The Darklords use such beasts to scout for their armies. They are vicious creatures and are often ridden by Giaks. The left path leads towards Holmgard, and the right path leads off towards the Durncrag Mountains. The choice of route is yours.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 32,
                content : "If you wish to turn left, go to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 146,
                content : "If you wish to turn right, go to"
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 255
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 255,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Dragon Bridge",
            regionType : "BRIDGE",
            description : "The Dragon Bridge connects the northern and southern part of Summerlund.",
            imageUrl : "images/flight/regions/dragonbridge.png"
         },
         content : "The creature that you now face is a Gourgaz, one of a race of cold-blooded reptilian creatures that dwell deep in the treacherous Maakenmire swamps. Their favourite food is human flesh! The Prince’s Sword lies at your feet. You may pick up and use this weapon if you wish. The Gourgaz is about to strike at you—you must fight him to the death.",
         events :  [
            {
                eventType : "ACQUIRE_ITEM_EVENT",
                ranking : 1,
                item : {
                    name : "Amethyst Sword",
                    itemType : "MAGICAL_ITEM",
                    description : "Prince Yisun Qis sword",
                    weight : "SMALL",
                    imageUrl : "images/flight/items/amethystsword.png"
                }
            }, {
                eventType : "COMBAT",
                ranking : 2,
                creature : {
                    name : "Gourgaz",
                    combatSkill : 20,
                    endurance : 30,
                    imageUrl : "images/flight/creatures/gourgaz.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 82,
                content : "If you win, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 256
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 256,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "You are awoken by the cries of Kraan high above you in the clear morning sky. Rubbing your eyes, you peer upwards through the canopy of branches to see three of the loathsome creatures fly off towards the north. You are sure you have not been spotted, but perhaps it would be best to leave now—just in case. You mount your horse and ride south along the highway.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 224,
                content : "Tunr to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 257
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 257,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Graveyard of the Ancients",
            regionType : "GRAVEYARD",
            description : "The Graveyard of the Ancients is an ancient, mist-shrouded graveyard just North of Holmgard. This place is taboo because of the nameless horrors that inhabit it. No one knows who lies in eternal unrest here but the Evil that lives there is more ancient than the Darklords.",
            imageUrl : "images/flight/regions/graveyardofancients.png"
         },
         content : "You find a stone portal in the east wall, but there does not appear to be any way of opening it.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 133,
                content : "If you wish to examine the statue, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 161,
                content : "If you wish to sit on the seat, turn to"
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 258
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 258,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Silvermoon Lake",
            regionType : "LAKE",
            description : "The Silvermoon Lake is a ...",
            imageUrl : "images/flight/regions/silvermoonlake.png"
         },
         content : "Using your Kai Discipline of Mind Over Matter, you untie the ropes binding your hands. You wait for a chance to make a break for it and then sprint as fast as you can into the dense undergrowth. Black arrows whistle past you, but you are soon deep among the trees and safe again. You have lost your Backpack and Weapons but you have your life and limbs intact. You continue to push on into the forest.",
         events :  [
            {
                eventType : "DROP_ALL_WEAPONS_EVENT",
                ranking : 1
            }, {
                eventType : "DROP_BACKPACK_EVENT",
                ranking : 2
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 50,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 259
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 259,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region: {
            name : "Darkstone Temple",
            regionType : "EVIL_TEMPLE",
            description : "It was only by an unlucky chance you discovered teh secret temple of a sect of evil druids",
            imageUrl : "images/flight/regions/darkstonetemple.png"
         },
         content : "The room is getting colder. You gradually notice the smell of sulphur in the air. You can hear chanting in the distance. It sounds as if it is somewhere in another part of this cave. A slit in the stone wall opens, and the end of a black staff begins to appear. Suddenly a bolt of blue lightning leaps from the staff and hits you in the chest. As your life slowly drains away, the last thing you see is an old man dressed in black robes raising a dagger above your throat. Your life and your mission end here.",
         events :  [
            {
                eventType : "MISSION_FAILED_EVENT",
                ranking : 1
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 260
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 260,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         content : "Swimming towards the bank, you can see the ranger spread-eagled at the water’s edge. You reach him but only to find that he has broken his neck in the fall and is dead. Suddenly, two Giaks jump on you from above and you must fight them.",
         events :  [
            {
                eventType : "COMBAT",
                ranking : 1,
                creature : {
                    name : "Giak",
                    combatSkill : 9,
                    endurance : 9,
                    imageUrl : "images/flight/creatures/giak.png"
                }
            },{
                eventType : "COMBAT",
                ranking : 2,
                creature : {
                    name : "Giak",
                    combatSkill : 8,
                    endurance : 11,
                    imageUrl : "images/flight/creatures/giak.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 156,
                content : "If you win, turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 261
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 261,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "Sweating, and out of breath, you part the dense undergrowth to see a Kraan hovering over the wagon. Three ghoulish Giaks drop from its back, startling the horses. They advance upon the helpless children with their spears.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 208,
                content : "If you wish to run back to the wagon and defend the children, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 264,
                content : "If you want to run deeper into the forest, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 262
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 262,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "The merchant takes your Gold and clicks his fingers. His bodyguard attacks you with his scimitar.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 191,
                content : "If you wish to fight, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 234,
                content : "If you wish to evade combat, jump clear of the speeding caravan by turning to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 263
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 263,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Clearing",
            regionType : "CLEARING",
            description : "You pass through a long, dark tunnel of voerhanging branches that eventually opens out into a large clearing.",
            imageUrl : "images/flight/regions/clearing.png"
         },
         content : "Carefully, you follow the stream as it makes its way towards the east. Suddenly you notice something in the distance that brings you to a halt. Lying in the rushing water like a great black dam is a dead Kraan. You creep nearer, under cover of the foliage, until you see three arrows deep in the beast’s chest. Trapped beneath the beast is the body of its rider. It is a Giak, a spiteful and malicious servant of the Darklords. Many centuries ago, their ancestors were used by the Darklords to build the infernal city of Helgedad, which lies in the volcanic wastelands beyond the Durncrag range of mountains. The construction of the city was a long and torturous nightmare, and only the strongest Giaks survived the heat and poisonous atmospheres of Helgedad. This creature is a descendant of these Giak slaves. It seems that this one must have drowned. The Giak’s pouch contains 3 Gold Crowns.",
         events :  [
            {
                eventType : "CHANGE_GOLD_AMOUNT_EVENT",
                ranking : 1,
                amount : 3
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 70,
                content : "You may continue downstream, by turning to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 157,
                content : "Or you may leave the stream and make your way on foot through the wooded hills to the south by turning to"
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 264
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 264,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "You have not gone far when you hear the sound of battle to the west.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 97,
                content : "If you wish to follow the sound, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 6,
                content : "If you would rather continue south, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 265
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 265,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "You quickly move off into the forest before more Doomwolves or Kraan appear.You have walked for more than an hour when you reach the top of a rocky hill. The sight that befalls you on the other side is one of hope. But there is also a daunting challenge to be faced.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 142,
                content : "Turn to "
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 266
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 266,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Graveyard of the Ancients",
            regionType : "GRAVEYARD",
            description : "The Graveyard of the Ancients is an ancient, mist-shrouded graveyard just North of Holmgard. This place is taboo because of the nameless horrors that inhabit it. No one knows who lies in eternal unrest here but the Evil that lives there is more ancient than the Darklords.",
            imageUrl : "images/flight/regions/graveyardofancients.png"
         },
         content : "As the beast writhes in its final death agony on the black stone floor, the portal in the east wall clicks open to reveal a corridor beyond. You quickly dash through the secret door just as it crashes shut.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 209,
                content : "Turn to"
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 267
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 267,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "Covering your nose with your cloak, you cautiously approach the dead beast. The sharp smell of its fetid black blood makes your stomach churn, but you are determined to press on. Then you notice a large saddlebag strapped to its chest. Opening the bag, you find a Message written on an animal skin. Deeper in the bag is a Dagger. You may keep both the Message and the Dagger if you wish. You leave the body and continue eastwards along the path.",
         events :  [
            {
                eventType : "ACQUIRE_ITEM_EVENT",
                ranking : 1,
                item : {
                    name : "Dagger",
                    itemType : "WEAPON",
                    description : "Dagger",
                    weight : "SMALL",
                    imageUrl : "images/flight/items/dagger.png"
                }
            }, {
                eventType : "ACQUIRE_ITEM_EVENT",
                ranking : 2,
                item : {
                    name : "Giak Scroll",
                    itemType : "SCROLL",
                    description : "Giak Scroll",
                    weight : "SMALL",
                    imageUrl : "images/flight/items/giakscroll.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 125,
                content : "Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 268
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 268,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Boat Crossing",
            regionType : "CITY_OUTSKIRTS",
            description : "The outer fildworks of the city can now be seen.",
            imageUrl : "images/flight/regions/holmguardoutskirts.png"
         },
         content : "You black out for only a few minutes before you are revived with a measure of strong spirit. Feeling weary but thankful to be alive, you lean on the shoulders of the King’s men and you stagger towards the outer defences.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 288,
                content : "Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 269
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 269,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Holmgard",
            regionType : "CITY",
            description : "Holmgard is the capital of Sommerlund and is a seaport on the Holmgulf. It is located near the Graveyard of the Ancients. The city is enclosed by grey-white walls two hundred feet in height whose gatehouses are 100 yards long. At the center of the city is the Citadel of the King.",
            imageUrl : "images/flight/regions/holmguard.png"
         },
         content : "The madman lies dead at your feet. Two soldiers soon appear at the doorway and immediately congratulate you. They tell you that he was an escaped lunatic whom they had been tracking for the last two days. One of the soldiers gives you 10 Gold Crowns reward money and offers to escort you to the citadel.",
         events :  [
            {
                eventType : "CHANGE_GOLD_AMOUNT_EVENT",
                ranking : 1,
                amount : 3
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 314,
                content : "If you accept his offer, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr :7,
                content : "If you would prefer to trust your own sense of direction, turn to"
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 270
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 270,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Yellow Marsh",
            regionType : "MARSH",
            description : "You soon realize that you are walking deeper into a wooded marsh.",
            imageUrl : "images/flight/regions/yellowmarch.png"
         },
         content : "You hear the angry cries of the enemy drift across the lake. You must leave here before more Kraan appear. You mount your steed and push on further into the forest.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 21,
                content : "Turn to"
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 271
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 271,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "You feel very weak. The poison of the snake has entered your bloodstream and you can feel the muscles of your body involuntarily tightening and relaxing. Your legs suddenly collapse beneath you and you feel the slimy water of the marsh close over your head. Your life ends here.",
         events :  [
            {
                eventType : "MISSION_FAILED_EVENT",
                ranking : 1
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 272
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 272,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Fogwood",
            regionType : "VILLAGE",
            description : "A little path through the wood leads to Gogwood, a small cluster of huts that have beein used by a family of charcoal burnder for nearly fifty years.",
            imageUrl : "images/flight/regions/fogwood.png"
         },
         content : "Keeping a watchful eye on the sky above, you move quickly along the track. You recall that this route leads to Fogwood, a small cluster of huts that have been used by a family of charcoal burners for nearly fifty years. After twenty minutes you reach the edge of a clearing where the huts are grouped in a small circle. There is no sign of the usual mist of wood smoke which gives Fogwood its apt name, and the huts are unusually quiet.",
         outcomes :  [
            {
                outcomeType : "ABILITY",
                targetNr : 134,
                ability : {
                    abilityType : "TRACKING",
                    description : "This skill enables a Kai Lord to make the correct choice of a path in the wild, to discover the location of a person or object in a town or city and to read the secrets of footprints or tracks."
                },
                content : "If you have the Kai Discipline of Tracking, you may turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 305,
                content : "If you do not possess this skill, you prepare your weapon and stealthily approach the huts. Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 273
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 273,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Boat Crossing",
            regionType : "CITY_OUTSKIRTS",
            description : "The outer fildworks of the city can now be seen.",
            imageUrl : "images/flight/regions/holmguardoutskirts.png",
         },
         content : "The outer fieldworks of the city can now be seen. Drawn across the river is a line of barges chained together to form a floating barricade. You can also see soldiers running along the log walls of the fieldworks, and you can hear the faint noise of battle drifting from the west.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 179,
                content : "If you wish to approach the barges, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 51,
                content : "If you wish to take cover in the trees, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 274
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 274,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
          region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "In your haste to avoid the enemy, you catch your foot in a tree root and you are pitched head over heels in a tumble of dust and leaves. You quickly get to your feet and, crashing through the undergrowth at the base of the hill, you run into the forest. You have been running for nearly ten minutes when you discover that you have lost your Weapon(s). Well, at least you still have your life and your Backpack. Wiping the grime from your face, you push on through the trees ahead.",
         events :  [
            {
                eventType : "DROP_ALL_WEAPONS_EVENT",
                ranking : 1
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 331,
                content : "Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 275
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 275,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "You have followed this twisting track for about twenty minutes when you hear the beating of wings high above the trees. Looking up you see a large Kraan approaching from the north, its huge black wings casting a gigantic shadow on the trees below. On its back are two creatures armed with long spears. They are Mountain Giaks—small ugly creatures full of hatred and malice. Many centuries ago, their ancestors were used by the Darklords to build the infernal city of Helgedad, which lies in the volcanic wastelands beyond the Durncrag mountain range. The construction of the city was long and torturous, and only the strongest of the creatures survived the heat and poisonous atmosphere of Helgedad. Quickly you dive for the shelter of a large fern tree as the Kraan passes overhead. With heart pounding, you pray that your quick reactions have saved you from being spotted. Pick a number from the Random Number Table.",
         outcomes :  [
             {
                outcomeType : "RANDOM",
                targetNr : 345,
                intervall : {
                    min : 0,
                    max : 4
                },
                content : "If the number you have picked is 0–4, turn to"
            }, {
                outcomeType : "RANDOM",
                targetNr : 74,
                intervall : {
                    min : 5,
                    max : 9
                },
                content : "If the number is 5–9, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 276
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 276,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "Reaching for your weapon you manage to hack your way through the tangle of wood and twisted branches to the clearer forest beyond. Your cloak is torn in several places and your right leg is badly bruised above the knee.",
         events :  [
            {
                eventType : "CHANGE_ENDURANCE_EVENT",
                ranking : 1,
                amount : -1
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 213,
                content : "Lose 1 ENDURANCE point and turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 277
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 277,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "When you awake, you find yourself lying at the foot of a steep slope in a tangle of tall grasses. Your Backpack and Weapon are missing and your head aches. You cannot tell how long you have been unconscious, but you realize that you must not delay in pressing on with your mission. Standing up, you see your Backpack is intact but one Weapon is broken in two and is now useless. Remember to cross it off your Action Chart. You quickly pick up your Backpack and move off into the trees ahead.",
         events : [
            {
                eventType : "DROP_WEAPON_EVENT",
                ranking : 1
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 113,
                content : "Turn to"
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 278
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 278,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "You quickly leave the path and gallop off along the track heading towards the capital. When you reach the point where the Doomwolves stopped, you can see just beyond a meadow the main highway which runs from the northern port of Toran to Holmgard. You should reach the capital by morning.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 149,
                content : "Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 279
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 279,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "You clamber over the loose rocks and into the mouth of the cave, and then quickly turn to push a large rock over the entrance. After a few minutes you see the Giaks on the rocky ledge outside, their evil yellow eyes furtively searching every crevice of the hillside. They are so close that you feel sure that they must spot you any second now. Pick a number from the Random Number Table.",
         outcomes :  [
            {
                outcomeType : "RANDOM",
                targetNr : 112,
                intervall : {
                    min : 0,
                    max : 6
                },
                content : "If the number you have picked is 0–6, turn to"
            }, {
                outcomeType : "RANDOM",
                targetNr : 96,
                intervall : {
                    min : 7,
                    max : 9
                },
                content : "If the number is 7–9, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 280
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 280,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "As you begin your climb, you hear the beat of wings approaching from the west. Kraan! By the noise they are making you estimate there are at least ten, perhaps more. You curse your bad luck, for the hillside offers no cover from the sky. If you are attacked during this difficult climb, you will find it nearly impossible to fight back and remain upright at the same time.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 327,
                content : "If you decide to draw your weapon and remain completely still, in the hope that the Kraan will not spot you, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 170,
                content : "If you decide to quickly descend the hillside and take cover in the tunnel, turn to"
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 281
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 281,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "As you race through the trees you can hear the horrible cackle of the Giaks close behind you. Soon the trees start to thin out and directly ahead you can see a rocky hillside.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 311,
                content : "f you break cover and climb up the hill, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 77,
                content : "If you change direction and continue your run through the forest, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 282
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 282,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Kings Citadel",
            regionType : "CITADEL",
            description : "The Kings Citadel is the highest law enforcement and paramilitary organization in Holmgard.",
            imageUrl : "images/flight/regions/holmguardcitadel.png"
         },
         content : "Looking above the heads of the crowd, you notice that one of the shops opposite the main gate is the timbered surgery of a city physician. Suddenly, a bold plan springs to mind. Bracing yourself against the tide of bodies, you struggle across to the other side of the street. You quickly enter to find that there is no sign of life, apart from a brightly coloured parrot in its cage by the window. Taking a selection of small bottles you slip on a white surgeon’s cloak, and fight your way back to the main gate. ‘An emergency!’ you bluff, as guards stop and question you. ‘It’s the royal cook’s wife ... she’s having a baby.’ The guards hesitate for a moment, but you assure them that the matter is most urgent and they decide to let you in. One of the great doors swings open about two feet, and you are roughly pushed through the narrow gap into the courtyard beyond.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 11,
                content : "Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 283
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 283,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
          region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "You are only ten feet or so away from the robed stranger when the raven squawks a warning to its master who instantly spins around. You are frozen in your tracks by the hideous apparition of a Vordak, a lieutenant of the Darklords and one of the undead. You must fight him. Due to the surprise of your attack, you may add 2 points to your COMBAT SKILL for the first round of combat only. Unless you have the Kai Discipline of Mindshield, deduct 2 points from your COMBAT SKILL for the second and subsequent rounds of fighting, for the creature is attacking you with the power of its Mindforce as well as with a large black mace!",
         events :  [
            {
                eventType : "TEMPORARY_CHANGE_COMBAT_SKILL_EVENT",
                ranking : 1,
                amount : 2
            }, {
                eventType : "COMBAT",
                ranking : 2,
                creature : {
                    name : "Vordak",
                    combatSkill : 18,
                    endurance : 25,
                    imageUrl : "images/flight/creatures/vordak.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 123,
                content : "If you win, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 284
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 284,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Graveyard of the Ancients",
            regionType : "GRAVEYARD",
            description : "The Graveyard of the Ancients is an ancient, mist-shrouded graveyard just North of Holmgard. This place is taboo because of the nameless horrors that inhabit it. No one knows who lies in eternal unrest here but the Evil that lives there is more ancient than the Darklords.",
            imageUrl : "images/flight/regions/graveyardofancients.png"
         },
         content : "Your passage through the Graveyard will not be easy, for the ground is broken and covered with a thorny graveweed. This wicked briar tears your cloak and cuts your legs. The air hangs heavy and still. Foul gases seep from open crypts and the haunting murmur of distant whispering fills your ears. Carefully, you approach a gap between two ancient pillars, and part the graveweed with your cloaked hand. Suddenly, the ground collapses beneath you and you fall in a tumble of earth and stone.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 71,
                content : "Turn to"
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 285
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 285,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Ruins of Raumas",
            regionType : "TEMPLE_RUIN",
            description : "Edging nearer, you soon make out a clearing that you recognize to be the site of the ruins of Raumas.",
            imageUrl : "images/flight/regions/runinsofraumas.png"
         },
         content : "With a sickening thud, the chunk of marble cracks open the back of the Giak’s head. The creature drops to its knees and slowly falls forward, down to the ruins below. Elated by your skill, you race forward to aid the young wizard.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 235,
                content : "Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 286
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 286,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "Messengers of death—and ones eager to deliver their news—the Doomwolves surround and then attack you. Valiantly you fight, but it is to no avail for there are too many of them. As your life’s blood seeps away and eternal dark approaches, the last sight you remember is the glint of sunlight on the spires of Holmgard. You have failed in your mission.",
         events :  [
            {
                eventType : "MISSION_FAILED_EVENT",
                ranking : 1
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 287
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 287,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "The track soon disappears completely into a tangle of thorny brambles and low-branched fir trees.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 13,
                content : "If you decide to return to the junction and head east, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 330,
                content : "If you decide to hack your way slowly through the undergrowth in this present direction, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 288
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 288,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Boat Crossing",
            regionType : "CITY_OUTSKIRTS",
            description : "The outer fildworks of the city can now be seen.",
            imageUrl : "images/flight/regions/holmguardoutskirts.png"
         },
         content : "As you reach the walls of the fieldworks, the large oak gates open and you are quickly hurried inside. A sergeant, bloodstained and battle-weary, calls to an officer who turns and recognizes your cloak. ‘My Lord,’ he says. ‘Where are the other Kai Masters? We are in desperate need of their wisdom. The Darklords press us most cruelly and casualties are high. You inform the brave officer of the terrible fate of your kinsmen, and the urgency of your mission to seek the King’s council. Without saying a word, he motions to a soldier to bring forward two horses. You both mount and gallop off towards the high city wall of Holmgard.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 129,
                content : "Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 289
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 289,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Kings Citadel",
            regionType : "CITADEL",
            description : "The Kings Citadel is the highest law enforcement and paramilitary organization in Holmgard.",
            imageUrl : "images/flight/regions/holmguardcitadel.png"
         },
         content : "The two guards look tired and anxious. They nervously hold their royal halberds in front of themselves, using the weapons to push away anyone who comes too close to the gates. An angry woman attacks one of them, pounding his chest with her clenched fists making him fall against the other guard. All three collapse in a struggling heap of flailing arms and legs. Seeing your chance, you dash forward and pull the large lever which opens the great doors. You slip inside and the doors close without either of the guards seeing you enter.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 139,
                content : "Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 290
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 290,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "Inside the long box is a sword wrapped in leather. You may take this Weapon if you wish. You close the box and descend the ladder to the clearing below, taking care to use only the sound rungs.",
         events :  [
            {
                eventType : "ACQUIRE_ITEM_EVENT",
                ranking : 1,
                item : {
                    name : "Sword",
                    itemType : "WEAPON",
                    description : "Sword",
                    weight : "MEDIUM",
                    imageUrl : "images/flight/items/sword.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 140,
                content : "Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 291
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 291,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "The two Giaks lie at your feet, their bodies twisted and lifeless. A quick search reveals 6 Gold Crowns, 2 Spears, and a Dagger. You may keep the Gold and take either the Dagger or a Spear. Remember to mark this on your Action Chart. The Kraan flew off during your battle, and the track is now deserted. You adjust your Backpack and continue your mission.",
         events :  [
            {
                eventType : "ACQUIRE_ITEM_EVENT",
                ranking : 1,
                item : {
                    name : "Sword",
                    itemType : "WEAPON",
                    description : "Sword",
                    weight : "MEDIUM",
                    imageUrl : "images/flight/items/sword.png"
                }
            }, {
                eventType : "ACQUIRE_ITEM_EVENT",
                ranking : 2,
                item : {
                    name : "Spear",
                    itemType : "WEAPON",
                    description : "Spear",
                    weight : "MEDIUM",
                    imageUrl : "images/flight/items/spear.png"
                }
            }, {
                eventType : "CHANGE_GOLD_AMOUNT_EVENT",
                ranking : 3,
                amount : 6
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 272,
                content : "Turn to"
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 292
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 292,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Graveyard of the Ancients",
            regionType : "GRAVEYARD",
            description : "The Graveyard of the Ancients is an ancient, mist-shrouded graveyard just North of Holmgard. This place is taboo because of the nameless horrors that inhabit it. No one knows who lies in eternal unrest here but the Evil that lives there is more ancient than the Darklords.",
            imageUrl : "images/flight/regions/graveyardofancients.png"
         },
         content : "The last thing that you experience of this life is the feeling of being sucked into the void of darkness. No trace of you remains in this world, for you have passed into a realm of timeless existence. You have become a slave of an ancient evil. Your adventure ends here.",
         events :  [
             {
                eventType : "MISSION_FAILED_EVENT",
                ranking : 1
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 293
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 293,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Ruins of Raumas",
            regionType : "TEMPLE_RUIN",
            description : "Edging nearer, you soon make out a clearing that you recognize to be the site of the ruins of Raumas.",
            imageUrl : "images/flight/regions/runinsofraumas.png"
         },
         content : "With a wave of his hand, Banedon leaves the ruins and you continue your mission, pushing on through the thick woods ahead. You have not gone far when you realize several pairs of yellow eyes are watching you from the undergrowth to your left. Suddenly, a black arrow skims the top of your head. It is a Giak ambush and you must run as fast as you can to escape it.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 281,
                content : "Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 294
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 294,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Silvermoon Lake",
            regionType : "LAKE",
            description : "The Silvermoon Lake is a ...",
            imageUrl : "images/flight/regions/silvermoonlake.png"
         },
         content : "Staying underwater for as long as you can, you finally surface to see the Giaks far behind you. You have lost your Weapon(s) and Backpack but at least you are still alive. You wade out of the muddy water and continue your journey under cover of the trees that line the right-hand bank. Pick a number from the Random Number Table.",
         outcomes :  [
            {
                outcomeType : "RANDOM",
                targetNr : 230,
                intervall : {
                    min : 0,
                    max : 2
                },
                content : "If the number you pick is 0–2, turn to"
            },{
                outcomeType : "RANDOM",
                targetNr : 190,
                intervall : {
                    min : 3,
                    max : 6
                },
                content : "If the number is 3–6, turn to"
            },{
                outcomeType : "RANDOM",
                targetNr : 321,
                intervall : {
                    min : 7,
                    max : 9
                },
                content : "If the number is 7–9, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 295
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 295,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "You have continued your journey for about fifteen minutes when suddenly a black arrow whistles past your head and embeds itself in a tree. Instinctively you duck and draw your weapon.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 185,
                content : "If you wish to remain where you are in order to try to spot the hidden archer, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 92,
                content : "If you wish to run for the cover of denser undergrowth, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 296
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 296,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Silvermoon Lake",
            regionType : "LAKE",
            description : "The Silvermoon Lake is a ...",
            imageUrl : "images/flight/regions/silvermoonlake.png"
         },
         content : "You sense something is wrong. With fighting all around and the forces of the Darklords so near, why has this man stayed in the forest? You feel a strange aura of evil about him and decline his offer.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 90,
                content : "Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 297
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 297,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "Using the skills taught to you by your masters in the art of Hunting, you inch your way through the foliage undetected. In less than a minute you are directly behind, and only a few feet from, the stake to which the ranger is tied. The wood is alight and great clouds of smoke are engulfing the poor victim. You take your weapon and run forward, hidden by the smoke. One blow of your weapon is all that is needed to sever his bonds, and you pull him free and back into the safety of the forest. As you press on into the forest, you hear the shrieks of the Giaks as they discover that their prisoner has literally disappeared in a cloud of smoke!",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 117,
                content : "Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 298
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 298,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "The head of the bird slowly turns and it curses you. An instant later, it flies off above the trees and has soon disappeared. Shocked by what you have heard you are now sure that the fledgling was a scout of the Darklords and is now probably on its way to inform them of your whereabouts.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 121,
                content : "If you wish to continue your journey along the track, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 38,
                content : "If you wish to leave the track and continue through the forest instead, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 299
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 299,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Yellow Marsh",
            regionType : "MARSH",
            description : "You soon realize that you are walking deeper into a wooded marsh.",
            imageUrl : "images/flight/regions/yellowmarch.png"
         },
         content : "You soon realize that you are walking deeper into a wooded marsh. To continue in this direction will be slow and hazardous.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 227,
                content : "If you wish to continue, turn to"
            },  {
                outcomeType : "DEFAULT",
                targetNr : 95,
                content : "If you wish to change direction and head towards firmer ground, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 300
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 300,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "You walk for over an hour, during which time you keep a constant vigil for any sign of Kraan in the sky above. You have twice spotted their tell-tale shadows in the sky and on both occasions your quick wits have saved you from capture. You are now very hungry and must eat a Meal.",
         events :  [
            {
                eventType : "CHANGE_RATION_AMOUNT_EVENT",
                ranking : 1,
                amount : -1
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 13,
                content : "You may now continue on your journey by turning to"
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 301
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 301,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Clearing",
            regionType : "CLEARING",
            description : "You pass through a long, dark tunnel of voerhanging branches that eventually opens out into a large clearing.",
            imageUrl : "images/flight/regions/clearing.png"
         },
         content : "Your Kai Discipline reveals that the west path is a dead end.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 27,
                content : "You choose the south path and turn to"
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 302
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 302,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Ruins of Raumas",
            regionType : "TEMPLE_RUIN",
            description : "Edging nearer, you soon make out a clearing that you recognize to be the site of the ruins of Raumas.",
            imageUrl : "images/flight/regions/runinsofraumas.png"
         },
         content : "Pick a number from the Random Number Table.",
         outcomes :  [
            {
                outcomeType : "RANDOM",
                targetNr : 110,
                intervall : {
                    min : 0,
                    max : 2
                },
                content : "If the number you have picked is 0–2, turn to"
            }, {
                outcomeType : "RANDOM",
                targetNr : 285,
                intervall : {
                    min : 3,
                    max : 9
                },
                content : "If the number is 3–9, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 303
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 303,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "The forest here is sparse and hilly. It does not give much cover from an attack from the air. You move as quickly as you can from tree to tree, to avoid the Kraan but you can hear the sound of Doomwolves close behind.",
         outcomes :  [
            {
                outcomeType : "ABILITY",
                targetNr : 237,
                ability : {
                    abilityType : "CAMOUFLAGE",
                    description : "This Discipline enables a Kai Lord to blend in with his surroundings. In the countryside, he can hide undetected among trees and rocks and pass close to an enemy without being seen. In a town or city, it enables him to look and sound like a native of that area, and can help him to find shelter or a safe hiding place."
                },
                content : "If you have the Kai Discipline of Camouflage, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 72,
                content : "If you do not, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 304
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 304,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "The Gem feels incredibly hot and burns your hand. Lose 2 ENDURANCE points. You quickly pick it up with the edge of your Kai cloak and slip this Vordak Gem into your Backpack. A Gem that size must be worth hundreds of Crowns. But the Giaks are very close and their arrows whistle past your head as you turn and run for the safety of the forest.",
         events :  [
             {
                eventType : "CHANGE_ENDURANCE_EVENT",
                ranking : 1,
                amount : -2
            }, {
                eventType : "ACQUIRE_ITEM_EVENT",
                ranking : 2,
                item : {
                    name : "Glowing Gem",
                    itemType : "MAGICAL_ITEM",
                    description : "Glowing Gem",
                    weight : "SMALL",
                    imageUrl : "images/flight/items/glowinggem.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 2,
                content : "Turn to"
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 305
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 305,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "Through the open doorway of the first hut, you can see the body of a charcoal burner lying face down on the rough stone floor. He has been murdered, stabbed in the back by a spear. All his furniture and belongings have been smashed and broken and not one piece remains intact. This is the evil handiwork of Giaks without any doubt, for they delight in the destruction of all things. A quick check of the other huts reveals a similar story of murder and wreckage. In the last hut that you search, you discover a Giak Spear—proof of your suspicions. You may keep this Weapon if you wish. More determined than ever now to succeed in your mission, you continue along the track.",
         events : [
            {
                eventType : "ACQUIRE_ITEM_EVENT",
                ranking : 1,
                item : {
                    name : "Spear",
                    itemType : "WEAPON",
                    description : "Spear",
                    weight : "MEDIUM",
                    imageUrl : "images/flight/items/spear.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 105,
                content : "Turn to"
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 306
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 306,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Dragon Bridge",
            regionType : "BRIDGE",
            description : "The Dragon Bridge connects the northern and southern part of Summerlund.",
            imageUrl : "images/flight/regions/dragonbridge.png"
         },
         content : "The sound of battle gradually fades behind you. Suddenly, you are pulled to the ground. Three Drakkarim have dropped from a tree above. You struggle but it is useless for there are too many of them for you and they are very strong.The last thing that you hear is the vicious snarls of Drakkarim as they raise their spears. Your life and your mission end here.",
         events :  [
             {
                eventType : "MISSION_FAILED_EVENT",
                ranking : 1
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 307
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 307,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Treehouse",
            regionType : "WOOD_BUILDING",
            description : "Looking up through the massive branches you can see a large treehouse some twhety-five feet above teh ground. There is no ladder, but the ganreld bark of teh tree offers many footholds.",
            imageUrl : "images/flight/regions/treehouse.png"
         },
         content : "Your climb is swift and easy. It reminds you of the many trees that you climbed and explored near Toran as a child, when you wanted to pick fruit or to look out over the beautiful countryside of Sommerlund. Pushing open the treehouse door, you see an old hermit huddled in the corner of the small cabin. A look of great relief spreads across his face as he recognizes your green Kai cloak. He tells you that this area is full of Giaks, and that he has counted over forty Kraan flying over his home in the last three hours. They were heading east. He scurries over to a cupboard and returns with a plate of fresh fruit. You thank him and place the fruit in your Backpack. There is enough for one Meal. The hermit also produces a fine Warhammer and lays it upon a table by the door. Your need is greater than mine, Kai Lord,’ he says. ‘Please take this trusty Warhammer if you so wish. You may take this Weapon only if you exchange it for another Weapon already in your possession, for it is the only defence that the hermit has against the enemy. Thanking the old man, you carefully descend the tree and continue on your mission.",
         events :  [
            {
                eventType : "ACQUIRE_ITEM_EVENT",
                ranking : 1,
                item : {
                    name : "Warhammer",
                    itemType : "WEAPON",
                    description : "Warhammer",
                    weight : "HEAVY",
                    imageUrl : "images/flight/items/warhammer.png"
                }
            }, {
                eventType : "CHANGE_RATION_AMOUNT_EVENT",
                ranking : 2,
                amount : 1
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 213,
                content : "Turn to"
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 308
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 308,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "The stable door is open and you can hear the breathing of a horse from inside the darkened interior. Suddenly, the horse senses your presence and rushes past, knocking you to the ground. You lose 1 ENDURANCE point.",
         events :  [
            {
                eventType : "CHANGE_ENDURANCE_EVENT",
                ranking : 1,
                amount : -1
            }
         ],
         outcomes :  [
            {
                outcomeType : "ABILITY",
                targetNr : 122,
                ability : {
                    abilityType : "ANIMAL_KINSHIP",
                    description : "This skill enables a Kai Lord to communicate with some animals and to be able to guess the intentions of others."
                },
                content : "If you wish to use the Kai Discipline of Animal Kinship, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 233,
                content : "If you wish to chase after the runaway horse, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 309
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 309,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "You have taken less than ten paces when the raven squawks a warning to the stranger. Turning to face you, the robed creature utters a piercing screech that freezes your blood and grips your stomach with fear and panic. It is a Vordak, a lieutenant of the Darklords and one of the undead. Within seconds, a host of Giaks appear at its side and attack you. You fight bravely but you are greatly outnumbered. The last thing you remember is the icy grasp of the Vordak’s skeletal fingers as they close around your throat. Your life and your mission end here.",
         events :  [
            {
                eventType : "MISSION_FAILED_EVENT",
                ranking : 1
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 310
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 310,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Holmgard",
            regionType : "CITY",
            description : "Holmgard is the capital of Sommerlund and is a seaport on the Holmgulf. It is located near the Graveyard of the Ancients. The city is enclosed by grey-white walls two hundred feet in height whose gatehouses are 100 yards long. At the center of the city is the Citadel of the King.",
            imageUrl : "images/flight/regions/holmguard.png"
         },
         content : "You notice a small faded sign on the wall of a building opposite. You remember that the royal court sessions are held within the citadel and you are sure that the west road must lead there.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 37,
                content : "Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 311
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 311,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "The hillside is steep and the earth is loose and slippery. You chance a swift glance over your shoulder and see the two Giaks emerge from the woods. They start to climb after you. About halfway from the peak of the hill, you spot a cave to your right, almost totally hidden by a landslide.",
         outcomes :  [
            {
                outcomeType : "ABILITY",
                targetNr : 324,
                ability : {
                    abilityType : "CAMOUFLAGE",
                    description : "This Discipline enables a Kai Lord to blend in with his surroundings. In the countryside, he can hide undetected among trees and rocks and pass close to an enemy without being seen. In a town or city, it enables him to look and sound like a native of that area, and can help him to find shelter or a safe hiding place."
                },
                content : "If you have the Kai Discipline of Camouflage, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 279,
                content : "If you wish to hide in the cave, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 47,
                content : "If you wish to avoid the cave and continue your climb to the peak, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 312
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 312,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "You curse your ill luck. It seems that nature and the Darklords have conspired against you, but it does not shake your determination to reach the King. Wiping the sticky mud from your clothes, you turn and press on into the forest.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 299,
                content : "Turn to "
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 313
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 313,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "Wiping the foul Giak blood from your weapon, you quickly descend the hillside before the Kraan spots its dead riders. Many times you lose your footing on the loose rocks, falling several feet. Deduct 1 ENDURANCE point for cuts and bruises to your legs.",
         events :  [
             {
                eventType : "CHANGE_ENDURANCE_EVENT",
                ranking : 1,
                amount : -1
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 248,
                content : "Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 314
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 314,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },region : {
            name : "Kings Citadel",
            regionType : "CITADEL",
            description : "The Kings Citadel is the highest law enforcement and paramilitary organization in Holmgard.",
            imageUrl : "images/flight/regions/holmguardcitadel.png"
         },
         content : "It takes you nearly an hour to reach the citadel. When you arrive you find that the citizens of Holmgard are in panic and confusion. Your escort approaches the armoured guards at the main entrance and tells them of your urgent message for the King. Pick a number from the Random Number Table.",
         outcomes :  [
             {
                outcomeType : "RANDOM",
                targetNr : 341,
                intervall : {
                    min : 0,
                    max : 6
                },
                content : "If you have picked a number that is 0–6, turn to"
            }, {
                outcomeType : "RANDOM",
                targetNr : 98,
                intervall : {
                    min : 7,
                    max : 9
                },
                content : "If the number is 7–9, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 315
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 315,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Dragon Bridge",
            regionType : "BRIDGE",
            description : "The Dragon Bridge connects the northern and southern part of Summerlund.",
            imageUrl : "images/flight/regions/dragonbridge.png"
         },
         content : "Wrapped in a bundle of women’s clothing is a small velvet purse containing 6 Gold Crowns. You may take these items and continue your journey.",
         events :  [
            {
                eventType : "CHANGE_GOLD_AMOUNT_EVENT",
                ranking : 1,
                amount : 6
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 213,
                content : "Turn to"
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 316
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 316,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "In your haste to avoid the enemy, you catch your foot in a tree root and you are pitched head over heels in a tumble of dust and leaves. Crashing through the undergrowth at the base of the hill, you quickly pick up your weapon and run into the thick forest. The Kraan is no longer circling above, but you can make out the silhouette of two Giaks on the peak of the hill behind. Wiping the grime from your eyes, you wince as you discover a large bruise on your forehead. Without delay, you run deeper into the safety of the forest.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 331,
                content : "Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 317
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 317,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Boat Crossing",
            regionType : "CITY_OUTSKIRTS",
            description : "The outer fildworks of the city can now be seen.",
            imageUrl : "images/flight/regions/holmguardoutskirts.png"
         },
         content : "Instinctively you dive away from the stairs, and land on the stone floor. Your quick reactions have saved your life, for a vast granite block has fallen from the ceiling and crushed the steps, just in front of the lockplate! Shaken but still in one piece, you get to your feet. A shaft of dull grey light is seeping into the chamber from above, where the stone block was. Through a hole in the ceiling you can see a tangle of graveweed and the cloudy sky above. You clamber out of the tomb and head for the arched south gate of the necropolis as fast as possible. The pointed log walls of the city’s outer defence works are now visible.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 61,
                content : "Turn to"
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 318
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 318,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Boat Crossing",
            regionType : "CITY_OUTSKIRTS",
            description : "The outer fildworks of the city can now be seen.",
            imageUrl : "images/flight/regions/holmguardoutskirts.png"
         },
         content : "Two soldiers and a sergeant run towards you, their crossbows aimed at your head. As they get nearer, they recognize your Kai cloak and a look of relief spreads across their faces. ‘My Lord,’ says the sergeant, ‘where are the other Kai Masters? We are in desperate need of their wisdom. The Darklords press us most cruelly and our casualties are high.’ You inform the brave soldier of the fate of your kinsmen, and the urgency of your mission to see the King. He takes you back to the barges where an officer accompanies you on horseback towards the high walls and the main gate of Holmgard.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 129,
                content : "Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 319
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 319,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Clearing",
            regionType : "CLEARING",
            description : "You pass through a long, dark tunnel of voerhanging branches that eventually opens out into a large clearing.",
            imageUrl : "images/flight/regions/clearing.png"
         },
         content : "The slimy creature lets out a long, ghastly death-cry and collapses. You are near to panic and scramble to your feet, grabbing what you think to be your belt from the jaws of the dead beast. You can see light in the far distance, and you sprint for it as fast as you can. When you finally emerge into the daylight, you fall onto the leafy ground and fight for breath in painful gasps. Slowly sitting upright, you notice that you are still wearing your belt—you had not lost it after all. What you grabbed from the jaw of the Burrowcrawler was a leather strap with a small pouch and a sheathed Dagger halfway along it. You break open the clasp to find it contains 20 Gold Crowns. You may take both the Dagger and the Crowns if you are able to. Feeling a little better now, you gather your Equipment together and push on eastwards into the forest.",
         events :  [
            {
                eventType : "CHANGE_GOLD_AMOUNT_EVENT",
                ranking : 1,
                amount : 20
            }, {
                eventType : "ACQUIRE_ITEM_EVENT",
                ranking : 2,
                item : {
                    name : "Dagger",
                    itemType : "WEAPON",
                    description : "Dagger",
                    weight : "SMALL",
                    imageUrl : "images/flight/items/dagger.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 157,
                content : "Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 320
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 320,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "As you race across the open field towards the wood, a Kraan dives at you and claws your arm. Before you can fight back, it has flown off again, shrieking with cold malice. You enter the wood, but you have lost 2 ENDURANCE points.",
         events :  [
            {
                eventType : "CHANGE_ENDURANCE_EVENT",
                ranking : 1,
                amount : -2
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 264,
                content : "Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 321
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 321,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Silvermoon Lake",
            regionType : "LAKE",
            description : "The Silvermoon Lake is a ...",
            imageUrl : "images/flight/regions/silvermoonlake.png"
         },
         content : "You walk for nearly an hour along the twisting river’s edge. Beyond the next turn you can hear the faint noise of battle. You carefully climb a steep hillock to get a better view of the area.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 269,
                content : "Turn to"
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 322
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 322,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "After what seems an eternity of struggling, you reach the peak of the steep hill. Behind you, above the canopy of trees, you can see the still smouldering remains of the monastery. To the north, a column of jet-black smoke rises high into the sky. Small orange tongues of flame flicker at its base. Your heart sinks as you realize that the port of Toran is ablaze. Suddenly, a piercing cry above warns you that a Kraan is about to attack. It is about thirty yards away and diving for the kill.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 17,
                content : "If you are going to stand and fight it as it swoops down, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 89,
                content : "If you are going to evade its attack and slide down the other side of the hill, away from the Kraan, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 323
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 323,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Old Watch Tower",
            regionType : "WOOD_BUILDING",
            description : "The old Watchtower is ...",
            imageUrl : "images/flight/regions/ruinwatchtower.png"
         },
         content : "From the top of the tower you can see above the trees in all directions. Far to the north, a column of jet-black smoke rises high into the sky. Small orange tongues of flame flicker at its base. Your heart sinks as you realize that the port of Toran is ablaze. From the southwest, the wind carries the noise of battle. It is close; no more than five miles at most. On the floor of the watchtower is a large oblong box.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 290,
                content : "If you wish to open this box, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 140,
                content : "If you would prefer to descend the ladder and leave the tower, taking care to use only the good rungs, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 324
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 324,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "You pull up your hood and drop down behind the rocks that litter the mouth of the cave. Holding your breath, you curl up into a tight ball, and completely cover yourself with your green cloak. Only a few minutes later the Giaks clamber over the rocky ledge outside, their evil yellow eyes furtively searching every crevice of the hillside. Then cursing in their strange tongue, they leave the ledge and start to climb towards the peak. You silently thank your old Masters for teaching you the Kai Discipline of Camouflage—it has probably saved your life on this occasion.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 33,
                content : "If you wish to explore the cave, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 248,
                content : "If you wish to leave and descend the hill in case the Giaks return, turn to"
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 325
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 325,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Ruins of Raumas",
            regionType : "TEMPLE_RUIN",
            description : "Edging nearer, you soon make out a clearing that you recognize to be the site of the ruins of Raumas.",
            imageUrl : "images/flight/regions/runinsofraumas.png"
         },
         content : "Upon seeing you emerge from the woods, the Giak officer shouts ‘Ogot! Ogot!’ to his cowering troops, who flee the ruins and run to the safety of the forest. Shaking his mailed fist at you, the black-clad Giak screams, ‘RANEG ROGAG OK—ORGADAKA OKAK ROGAG GAJ!’ before leaving. Surveying the scene of battle, you count over fifteen Giak dead lying among the broken pillars of Raumas. The young wizard wipes his brow and walks towards you, his hand extended in friendship.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 349,
                content : "Turn to"
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 326
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 326,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Graveyard of the Ancients",
            regionType : "GRAVEYARD",
            description : "The Graveyard of the Ancients is an ancient, mist-shrouded graveyard just North of Holmgard. This place is taboo because of the nameless horrors that inhabit it. No one knows who lies in eternal unrest here but the Evil that lives there is more ancient than the Darklords.",
            imageUrl : "images/flight/regions/graveyardofancients.png"
         },
         content : "You carefully insert the Key and turn it clockwise. You hear a dull click—the Key works. You lift out the pin, and the large granite door slowly swings towards you on hidden hinges. The grey half-light of the Graveyard floods into the tomb. The exit is overgrown with graveweed and you suffer many cuts to your face and arms as you fight your way through to the surface. Looking back, you see the tomb door slowly close and a cruel inhuman laugh seems to rise out of the very ground on which you stand. In blind panic, you race through the eerie necropolis towards the south gate.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 61,
                content : "Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 327
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 327,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "Within a few minutes, you can see the Kraan hovering over a hilltop behind you. At a quick count you can make out at least sixteen of these horrible creatures, each of which has at least two Giaks riding upon its back. They are armed with long spears and wear tall pointed helmets of dull bronze. You hear the excited grunts of the Giaks. They have spotted you. You jump for the entrance of the tunnel some twenty-five feet below, but your boot gets caught in a thorny briar and you hang helplessly upside down—weaponless and vulnerable. Fortunately for you the end is swift: As the first Giak lance pierces your heart, death is instantaneous. Your life and your mission end here.",
         events :  [
            {
                eventType : "MISSION_FAILED_EVENT",
                ranking : 1
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 328
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 328,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "As the creature dies, its body slowly dissolves into a vile green liquid. You notice that the grass and plants beneath the smoking fluid are beginning to shrivel and die. But a large valuable looking Gem lies on the ground near to the decaying body.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 76,
                content : "If you wish to take the Gem, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 118,
                content : "If you would rather leave as quickly as possible, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 329
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 329,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Graveyard of the Ancients",
            regionType : "GRAVEYARD",
            description : "The Graveyard of the Ancients is an ancient, mist-shrouded graveyard just North of Holmgard. This place is taboo because of the nameless horrors that inhabit it. No one knows who lies in eternal unrest here but the Evil that lives there is more ancient than the Darklords.",
            imageUrl : "images/flight/regions/graveyardofancients.png"
         },
         content : "As you descend the ridge towards the Graveyard of the Ancients, you are aware of a strange mist and cloud that swirls all around this grey and forbidding place, blocking the sun and keeping the Graveyard in perpetual gloom. A creeping chill seems to penetrate your very bones. Your horse becomes startled and no matter how you urge him on, he refuses to go any nearer to this dreadful place. So you must leave your horse and press on by foot.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 284,
                content : "Turn to"
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 330
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 330,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Dragon Bridge",
            regionType : "BRIDGE",
            description : "The Dragon Bridge connects the northern and southern part of Summerlund.",
            imageUrl : "images/flight/regions/dragonbridge.png"
         },
         content : "Fatigued by your exertions, you stop to rest for a few minutes at a fallen tree. You notice a large bundle, beneath the trunk.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 315,
                content : "If you wish to examine the contents of the bundle, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 213,
                content : "If you wish to leave it where it is and continue your mission, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 331
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 331,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Clearing",
            regionType : "CLEARING",
            description : "You pass through a long, dark tunnel of voerhanging branches that eventually opens out into a large clearing.",
            imageUrl : "images/flight/regions/clearing.png"
         },
         content : "Surrounded by thorny briars and closely packed roots, you see the entrance of a tunnel disappearing into the hillside beyond. It is approximately seven feet in height and just over ten feet wide. As you get closer, you can feel a slight breeze coming from the inky blackness. If the other end of this tunnel emerges on the far side of the hill, it could save you many hours of difficult climbing. But it could also harbour unknown danger.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 170,
                content : "If you wish to enter the tunnel, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 280,
                content : "If you would prefer to climb the hillside, turn to"
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 332
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 332,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Kings Citadel",
            regionType : "CITADEL",
            description : "The Kings Citadel is the highest law enforcement and paramilitary organization in Holmgard.",
            imageUrl : "images/flight/regions/holmguardcitadel.png"
         },
         content : "You walk for nearly ten minutes along a dark and winding corridor, and then start to climb a steep staircase to a small wooden door. The man presses a secret catch and the door opens. You enter a large, plushly decorated bedroom with a huge marble bath that takes up one corner of the room. The man suggests that you refresh yourself here whilst he seeks an audience with the King. You quickly bathe and change into some white robes that have been left out on a large marble table. Shortly, the man returns and leads you through a long corridor lined with exquisite tapestries. You finally arrive at a large door guarded by two soldiers wearing silver armour. You are about to meet the King.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 350,
                content : "Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 333
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 333,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "You have cut your way through the thick undergrowth for nearly half an hour when you hear the beat of wings high above the trees. Looking up you can just make out the shape of a Kraan approaching from the north. It is one of the monsters that attacked the monastery and on its back are two grey-skinned creatures armed with long spears. These are Mountain Giaks—evil servants of the Darklords, full of hatred and malice. Many centuries ago, their ancestors were used by the Darklords to build the infernal city of Helgedad, which lies in the volcanic wastelands beyond the Durncrag range of mountains. The construction of the city was long and torturous and only the strongest of the Giaks survived the heat and poisonous atmosphere of Helgedad. Hidden by the trees, you freeze, keeping absolutely still as the Kraan passes overhead and disappears towards the south. When you are sure that it has gone, you move off once again into the forest.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 131,
                content : "Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 334
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 334,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "As the stream vanishes up into the rocky hillside, you can see on the track above four soldiers and their officer. They wear the uniform of the King’s army.",
         outcomes :  [
            {
                outcomeType : "ABILITY",
                targetNr : 48,
                ability : {
                    abilityType : "SIXTH_SENSE",
                    description : "This skill may warn a Kai Lord of imminent danger. It may also reveal the true purpose of a stranger or strange object encountered in your adventure."
                },
                content : "If you wish to use the Kai Discipline of Sixth Sense, turn to"
            }, {
                outcomeType : "ABILITY",
                targetNr : 73,
                ability : {
                    abilityType : "CAMOUFLAGE",
                    description : "This Discipline enables a Kai Lord to blend in with his surroundings. In the countryside, he can hide undetected among trees and rocks and pass close to an enemy without being seen. In a town or city, it enables him to look and sound like a native of that area, and can help him to find shelter or a safe hiding place."
                },
                content : "If you wish to use the Kai Discipline of Camouflage and wait for them to pass, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 162,
                content : "If you wish to approach them, turn to"
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 335
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 335,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "As you approach, the black bird flies off above the trees and soon disappears from view. You search the tree on which it was perched but find nothing unusual. Rather than waste any more precious time, you continue off along the track.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 121,
                content : "Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 336
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 336,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "You rush into the clearing and take the Giaks completely by surprise. Without a moment’s hesitation, you strike out at the one nearest to you. He is dead before his body hits the ground. The other Giaks unsheathe their curved swords and attack you. You must fight them one at a time.",
         events :  [
            {
                eventType : "COMBAT",
                ranking : 1,
                creature : {
                    name : "Giak",
                    combatSkill : 13,
                    endurance : 10,
                    imageUrl : "images/flight/creatures/giak.png"
                }
            }, {
                eventType : "COMBAT",
                ranking : 2,
                creature : {
                    name : "Giak",
                    combatSkill : 12,
                    endurance : 10,
                    imageUrl : "images/flight/creatures/giak.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 117,
                content : "If you win, you free the ranger and turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 337
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 337,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Graveyard of the Ancients",
            regionType : "GRAVEYARD",
            description : "The Graveyard of the Ancients is an ancient, mist-shrouded graveyard just North of Holmgard. This place is taboo because of the nameless horrors that inhabit it. No one knows who lies in eternal unrest here but the Evil that lives there is more ancient than the Darklords.",
            imageUrl : "images/flight/regions/graveyardofancients.png"
         },
         content : "Just as you remove the ornate pin, a loud crack deafens you. Pick a number from the Random Number Table.",
         outcomes :  [
            {
                outcomeType : "RANDOM",
                targetNr : 219,
                intervall : {
                    min : 0,
                    max : 4
                },
                content : "If the number picked is 0–4, turn to"
            },{
                outcomeType : "RANDOM",
                targetNr : 317,
                intervall : {
                    min : 5,
                    max : 9
                },
                content : "If the number is 5–9, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 338
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 338,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "When you awake, you find yourself lying at the foot of a steep slope in a tangle of long grasses. Your Backpack and Weapons are missing and your head aches violently. You cannot tell how long you have been unconscious, but you realize that time is running out and you must press on. Standing up, you notice your Backpack and Weapon on the slope above. They must have broken free when you fell. You quickly retrieve them and move off into the trees ahead.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 113,
                content : "Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 339
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 339,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Holmgard",
            regionType : "CITY",
            description : "Holmgard is the capital of Sommerlund and is a seaport on the Holmgulf. It is located near the Graveyard of the Ancients. The city is enclosed by grey-white walls two hundred feet in height whose gatehouses are 100 yards long. At the center of the city is the Citadel of the King.",
            imageUrl : "images/flight/regions/holmguard.png"
         },
         content : "You quickly sidestep just as a long dagger shatters the glass top of the counter. A swarthy youth is attacking you and you must fight him.",
         events :  [
            {
                eventType : "COMBAT",
                ranking : 1,
                creature : {
                    name : "Human",
                    combatSkill : 10,
                    endurance : 10,
                    imageUrl : "images/flight/creatures/human.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 94,
                content : "If you kill him within 4 rounds of Combat, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 203,
                content : "If you are still fighting after 4 rounds of Combat, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 340
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 340,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Main Road",
            regionType : "ROAD",
            description : "The Main Road is the main passage between the port of Toran in the north and the capital in the south.",
            imageUrl : "images/flight/regions/sommerlundmainroad.png"
         },
         content : "You gallop forward to meet the oncoming Doomwolf and rider, your Weapon raised to strike. The Giak sees you and unsheathes his scimitar. You must fight both Giak and Doomwolf as one enemy.",
         events :  [
            {
                eventType : "COMBAT",
                ranking : 1,
                creature : {
                    name : "Doomwolf",
                    combatSkill : 12,
                    endurance : 12,
                    imageUrl : "images/flight/creatures/doomwolf.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 193,
                content : "If you win the fight, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 341
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 341,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Kings Citadel",
            regionType : "CITADEL",
            description : "The Kings Citadel is the highest law enforcement and paramilitary organization in Holmgard.",
            imageUrl : "images/flight/regions/holmguardcitadel.png"
         },
         content : "The guards do not believe your story and refuse to let you enter. Your escort disappears into the crowd and you are left alone to find your way in this confused city. Shocked, and then dejected by such a rebuff, you are carried along by the crowds until you find yourself at the entrance to the Guildhall. It stands at one side of the Guild Bridge which crosses the River Eledil near where it joins the Holmgulf.",
         outcomes :  [
            {
                outcomeType : "ABILITY",
                targetNr : 310,
                ability : {
                    abilityType : "TRACKING",
                    description : "This skill enables a Kai Lord to make the correct choice of a path in the wild, to discover the location of a person or object in a town or city and to read the secrets of footprints or tracks."
                },
                content : "If you wish to use the Kai Discipline of Tracking, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 210,
                content : "If you wish to enter the Guildhall, turn to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 37,
                content : "If you wish to search for another route into the citadel, turn to"
            }
         ]
    },  {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 342
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 342,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
          region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "As your voice echoes through the trees, the stranger slowly turns to face you. Your heart pounds and your blood freezes as you realize that the stranger is not human. It is a Vordak, a hideous lieutenant of the Darklords and one of the undead. A piercing scream fills your ears, and the creature raises a huge black mace above its head and charges at you. Frozen with horror, you can also feel the Vordak attacking you with the force of its mind.",
         events :  [
            {
                eventType : "COMBAT",
                ranking : 1,
                creature : {
                    name : "Vordak",
                    combatSkill : 18,
                    endurance : 25,
                    imageUrl : "images/flight/creatures/vordak.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 123,
                content : "If you win, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 343
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 343,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "You are held by the mass of tangled branches and roots. Eventually you free your right hand, grab your weapon, and hack your way slowly through the foliage to the clearer forest beyond. Your cloak is torn in several places and your left arm is cut and badly bruised above the elbow.",
         events :  [
            {
                eventType : "CHANGE_ENDURANCE_EVENT",
                ranking : 1,
                amount : -2
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 213,
                content : "Lose 2 ENDURANCE points and turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 344
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 344,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Holmgard",
            regionType : "CITY",
            description : "Holmgard is the capital of Sommerlund and is a seaport on the Holmgulf. It is located near the Graveyard of the Ancients. The city is enclosed by grey-white walls two hundred feet in height whose gatehouses are 100 yards long. At the center of the city is the Citadel of the King.",
            imageUrl : "images/flight/regions/holmguard.png"
         },
         content : "You are weak and dizzy. You can no longer feel your legs and they refuse to bear your weight. You try to crawl for the door but the robber jumps on you and pins you to the ground.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 340,
                content : "Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 345
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 345,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "You pull up the hood of your green Kai cloak and hold your breath as the Kraan circles above. After a few minutes, you hear the frantic curses of the Giaks. The beating of Kraan wings fades, as they disappear towards the west. Your quick reactions have saved you from capture and likely death.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 272,
                content : "You can now return to the track, by turning to"
            }, {
                outcomeType : "DEFAULT",
                targetNr : 19,
                content : "Or push on under cover of the trees. Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 346
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 346,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "Lodged deep in the rib cage of the skeleton is a Spear. It is in good condition and you may take it if you wish and are able to.",
         events :  [
             {
                eventType : "ACQUIRE_ITEM_EVENT",
                ranking : 1,
                item : {
                    name : "Spear",
                    itemType : "WEAPON",
                    description : "Spear",
                    weight : "MEDIUM",
                    imageUrl : "images/flight/items/spear.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 14,
                content : "To leave the clearing, turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 347
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 347,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Sommerlund Woodlands",
            regionType : "WOODS",
            description : "Deep Woods in Summerlund",
            imageUrl : "images/flight/regions/sommerlundwoodlands.png"
         },
         content : "The trees start to thin out, and just ahead you can make out the silhouette of an old log cabin beneath an oak tree. This hut seems to have been abandoned and there is little of apparent value left behind. Opening a small chest near the main door, you discover bunches of twigs that have been tied together with strong twine. One end of each bundle has been coated with pitch. They are Torches. Next to the chest are a Short Sword and a Tinderbox. You may take them and a Torch if you wish but make sure, that you mark them on your Action Chart. Closing the door of the cabin, you head off along an overgrown path towards the northeast.",
         events :  [
            {
                eventType : "ACQUIRE_ITEM_EVENT",
                ranking : 1,
                item : {
                    name : "Torch",
                    itemType : "UTILITY",
                    description : "Torch",
                    weight : "SMALL",
                    imageUrl : "images/flight/items/torch.png"
                }
            },{
                eventType : "ACQUIRE_ITEM_EVENT",
                ranking : 2,
                item : {
                    name : "Tinderbox",
                    itemType : "UTILITY",
                    description : "Tinderbox",
                    weight : "SMALL",
                    imageUrl : "images/flight/items/tinderbox.png"
                }
            },{
                eventType : "ACQUIRE_ITEM_EVENT",
                ranking : 3,
                item : {
                    name : "Sword",
                    itemType : "WEAPON",
                    description : "Sword",
                    weight : "MEDIUM",
                    imageUrl : "images/flight/items/sword.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 103,
                content : "Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 348
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 348,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Yellow Marsh",
            regionType : "MARSH",
            description : "You soon realize that you are walking deeper into a wooded marsh.",
            imageUrl : "images/flight/regions/yellowmarch.png"
         },
         content : "Raising your boot to kick away the dead snake, your heart skips a beat as you realize that it was a Red Marshviper. There is no known cure for its venomous bite! You decide that to go any further in this direction would be suicide. Carefully retracing your steps, you eventually reach firm ground and continue on your mission.",
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 95,
                content : "Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 349
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 349,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         region : {
            name : "Ruins of Raumas",
            regionType : "TEMPLE_RUIN",
            description : "Edging nearer, you soon make out a clearing that you recognize to be the site of the ruins of Raumas.",
            imageUrl : "images/flight/regions/runinsofraumas.png"
         },
         content : "He is a young blond-haired youth with deep brooding eyes. His face is lined with exhaustion and the grime of battle, and his long sky-blue robes bear evidence of living rough in the wilds. He shakes your hand and bows. ‘My eternal thanks, Kai Lord. My powers are nearly drained. Had you not come to my aid, I fear I would have ended my days atop a Giak lance.’ He is weak and unsteady on his feet. You take his arm and sit him down upon a fallen pillar where you listen intently to what he has to say. ‘My name is Banedon. I am journeyman to the Brotherhood of the Crystal Star, which is the Magicians’ Guild of Toran. My Guildmaster has sent me to your monastery with this urgent message.’ He removes a vellum envelope from inside his robes and handd it to you. ‘As you see, I have opened the letter and read its contents. When the war started, I was on the highway with two travelling companions. The Kraan attacked us and we lost each other in the forest during our escape. The letter is a warning to the Kai Lords that the Darklords have mustered a vast army beyond the Durncrag Range. The Guildmaster urges the Kai to cancel the celebrations of Fehmarn and prepare for war. I fear we were betrayed,’ says Banedon, his head bowed in sorrow. ‘One of my order, a brother called Vonotar, had explored the forbidden mysteries of the Black Art. Ten days ago he denounced the Brotherhood and killed one of our Elders. He has since disappeared. It is rumoured that he now aids the Darklords.’ You tell Banedon what has happened at the monastery, and of your mission to warn the King. Silently, he removes a gold chain from around his neck and hands it to you. On the chain is a small Crystal Star Pendant. ‘It is the symbol of my Brotherhood, and we are both truly brothers in this hour of darkness. It is a talisman of good fortune—may it protect you on your road ahead.’ You thank him, place the chain around your neck, and slip the Crystal Star4 inside your shirt. (Remember to mark this on your Action Chart.) Banedon bids you farewell. ‘We must leave this place lest the Giaks return with more of their loathsome kind to put an end to us. I must return to my Guild. I bid you farewell, my brother. May the luck of the gods go with you.’",
         events :  [
            {
                eventType : "ACQUIRE_ITEM_EVENT",
                ranking : 1,
                item : {
                    name : "Crystal Star",
                    itemType : "MAGICAL_ITEM",
                    description : "Crystal Star",
                    weight : "SMALL",
                    imageUrl : "images/flight/items/crystalstar.png"
                }
            }
         ],
         outcomes :  [
            {
                outcomeType : "DEFAULT",
                targetNr : 95,
                content : "Turn to"
            }
         ]
    }, {
        /*
         * -- --------------------------------------------------------
         * --  Storysection 350
         * -- --------------------------------------------------------
         */
         sectionType : "STORY_SECTION",
         sectionNr : 350,
         book : {
            name : "Flight from the dark",
            imageUrl : "images/flight/title.jpg",
            author : "Joe Dever",
            illustrator : "Gary Chalk"
         },
         content : "You enter the Chamber of State, a magnificent hall decorated lavishly in white and gold. The King and his closest advisers are studying a large map spread upon a marble plinth in the centre of the chamber. Their faces are lined with worry and concentration. A silence fills the hall as you tell of the death of your kinsmen and of your perilous journey to the citadel. As you finish your story, the King approaches and takes your right hand in his. Lone Wolf, you have selfless courage: the quality of a true Kai Lord. Your journey here has been one of great peril and although your news comes as a grievous blow, the spirit of your determination is like a beacon of hope to us all in this dark hour. You have brought great honour to the memory of your Masters, and for that we praise you.’ You receive the praise and heartfelt thanks of the entire hall—an honour that brings a certain redness to your young face. The King raises his hand and all the voices cease. ‘You have done all that Sommerlund could have asked of a loyal son, but she is greatly in need of you still. The Darklords are powerful once more and their ambition knows no bounds. Our only hope lies within Durenor with the power that once defeated the Darklords an age ago. Lone Wolf, you are the last of the Kai—you have the skills. Will you journey to Durenor and return with the Sommerswerd, the sword of the sun?  Only with that gift of the gods may we crush this evil and save our land.’ If you wish to accept the quest of the Sommerswerd, begin your adventure with Book 2 of the Lone Wolf adventures: Fire on the Water",
         events :  [
            {
                eventType : "MISSION_ACCOMPLISHED_EVENT",
                ranking : 1,
                book : {
                    name : "Flight from the dark",
                    imageUrl : "images/flight/title.jpg",
                    author : "Joe Dever",
                    illustrator : "Gary Chalk"
                }
            }
         ]
    }
]);

db.lw1.find();


