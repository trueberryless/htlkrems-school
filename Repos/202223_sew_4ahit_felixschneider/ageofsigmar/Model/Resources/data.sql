INSERT INTO CREATURES (CREATURE_ID, NAME, BODY, MIND, SOUL, ARMOUR, TOUGNESS, WOUNDS, METTLE, INITIATIVE, AWARENESS, DESCRIPTION) VALUES (1, 'Flamespyre Phoenix', 5, 4, 5, 1, 14, 0, 3, 9, 4, 'FLAMESPYRE PHOENIX
Great birds of aetheric flame, the Flamespyre Phoenixes
are resplendent hunters and noble warriors who wield the
primal fire of the godbeast known as the Ur-Phoenix as
gracefully as they soar through the air. When angered, their
naturally bright plumage explodes into searing flames,
leaving scorching trails across the sky as they swoop and
dive across the battlefield.
Though they are incapable of speech, they are capable of
forming pacts and executing complex strategies when they
need to. They perish in searing explosions, reigniting their
souls anew.
');
INSERT INTO CREATURES (CREATURE_ID, NAME, BODY, MIND, SOUL, ARMOUR, TOUGNESS, WOUNDS, METTLE, INITIATIVE, AWARENESS, DESCRIPTION) VALUES (2, 'Stardrake', 8, 6, 4, 3, 36, 9, 2, 7, 4, 'STARDRAKE
Dracothion’s eldest children descend from the heavens in
brilliant starfalls. Though Stardrakes resemble dragons,
the similarities are superficial; Stardrakes are celestial
beings, both radiating starlight and feeding on it as much
as they do the meat of lesser creatures. A Stardrake will
never consume anything touched by Chaos, though — for
those abominations they reserve incinerating lightning.
When they die, Stardrakes reincarnate among the stars,
rising again to fight against Chaos. Foreseeing their
extinction unless they act, the Stardrakes have ended their
long isolation to defy the Ruinous Powers.
');


INSERT INTO ATTACKS (ATTACK_ID, IDENTIFIER, ATTACK_TYPE, DAMAGE, CREATURE_ID) VALUES (1, 'Flaming Talons', 'MELEE_ATTACK', 7, 1);
INSERT INTO ATTACKS (ATTACK_ID, IDENTIFIER, ATTACK_TYPE, DAMAGE, CREATURE_ID) VALUES (2, 'Cavernous Jaws', 'MELEE_ATTACK', 10, 2);
INSERT INTO ATTACKS (ATTACK_ID, IDENTIFIER, ATTACK_TYPE, DAMAGE, CREATURE_ID) VALUES (3, 'Creat Claws', 'MELEE_ATTACK', 10, 2);
INSERT INTO ATTACKS (ATTACK_ID, IDENTIFIER, ATTACK_TYPE, DAMAGE, CREATURE_ID) VALUES (4, 'Sweeping Tail', 'MELEE_ATTACK', 10, 2);

INSERT INTO SKILLS (SKILL_ID, IDENTIFIER, SKILL_VALUE) VALUES (1, 'Awareness', 3);
INSERT INTO SKILLS (SKILL_ID, IDENTIFIER, SKILL_VALUE) VALUES (2, 'Reflexes', 2);
INSERT INTO SKILLS (SKILL_ID, IDENTIFIER, SKILL_VALUE) VALUES (3, 'Weapon Skill', 2);
INSERT INTO SKILLS (SKILL_ID, IDENTIFIER, SKILL_VALUE) VALUES (4, 'Arcana', 2);
INSERT INTO SKILLS (SKILL_ID, IDENTIFIER, SKILL_VALUE) VALUES (5, 'Channelling', 2);
INSERT INTO SKILLS (SKILL_ID, IDENTIFIER, SKILL_VALUE) VALUES (6, 'Determination', 2);
INSERT INTO SKILLS (SKILL_ID, IDENTIFIER, SKILL_VALUE) VALUES (7, 'Fortitude', 1);
INSERT INTO SKILLS (SKILL_ID, IDENTIFIER, SKILL_VALUE) VALUES (8, 'Might', 2);

INSERT INTO CREATURE_HAS_SKILLS_JT (CREATURE_ID, SKILL_ID) VALUES (1, 1);
INSERT INTO CREATURE_HAS_SKILLS_JT (CREATURE_ID, SKILL_ID) VALUES (1, 2);
INSERT INTO CREATURE_HAS_SKILLS_JT (CREATURE_ID, SKILL_ID) VALUES (1, 3);
INSERT INTO CREATURE_HAS_SKILLS_JT (CREATURE_ID, SKILL_ID) VALUES (2, 4);
INSERT INTO CREATURE_HAS_SKILLS_JT (CREATURE_ID, SKILL_ID) VALUES (2, 5);
INSERT INTO CREATURE_HAS_SKILLS_JT (CREATURE_ID, SKILL_ID) VALUES (2, 6);
INSERT INTO CREATURE_HAS_SKILLS_JT (CREATURE_ID, SKILL_ID) VALUES (2, 7);
INSERT INTO CREATURE_HAS_SKILLS_JT (CREATURE_ID, SKILL_ID) VALUES (2, 8);

INSERT INTO TRAITS (TRAIT_ID, IDENTIFIER, DESCRIPTION) VALUES (1, 'Attuned to Magic', 'A Flamespyre Phoenix is imbued with
potent magical energy. If an ally casts a spell while in the
same Zone as the Flamespyre Phoenix, the caster gains +1
Armour until the start of their next turn.
');
INSERT INTO TRAITS (TRAIT_ID, IDENTIFIER, DESCRIPTION) VALUES (2, 'Born of Fire', 'The Flamespyre Phoenix is immune to
Hazards and Damage from intense heat or flames.
');
INSERT INTO TRAITS (TRAIT_ID, IDENTIFIER, DESCRIPTION) VALUES (3, 'Phoenix Reborn', 'In the fires of battle, the phoenix is
born anew. Once per day, if the Flamespyre Phoenix is
killed, it returns to life at the start of its next turn with 14
Toughness.
');
INSERT INTO TRAITS (TRAIT_ID, IDENTIFIER, DESCRIPTION) VALUES (4, 'Wake of Fire', 'Streams of flames surround the Flamespyre
Phoenix. The Flamespyre Phoenix’s Zone is a Major Hazard
for any non-allies.
');
INSERT INTO TRAITS (TRAIT_ID, IDENTIFIER, DESCRIPTION) VALUES (5, 'Arcane Lineage', 'Stardrakes possess innate power over
the magic of the realms. Decrease the Complexity of
Mind (Channelling) Tests by 1 (to a minimum of 1) for
friendly spellcasters within Long Range, and increase the
Complexity by 1 for enemy spellcasters.
');
INSERT INTO TRAITS (TRAIT_ID, IDENTIFIER, DESCRIPTION) VALUES (6, 'Lord of Heavens', 'Lord of the Heavens: The Stardrake can cast the Chain
Lightning and Comet of Casandora spells, except the
DN of the spells is 5:1 and the Stardrake can use Body
(Channelling) instead of Mind (Channelling).
');


INSERT INTO CREATURE_HAS_TRAITS_JT (CREATURE_ID, TRAIT_ID) VALUES (1, 1);
INSERT INTO CREATURE_HAS_TRAITS_JT (CREATURE_ID, TRAIT_ID) VALUES (1, 2);
INSERT INTO CREATURE_HAS_TRAITS_JT (CREATURE_ID, TRAIT_ID) VALUES (1, 3);
INSERT INTO CREATURE_HAS_TRAITS_JT (CREATURE_ID, TRAIT_ID) VALUES (1, 4);
INSERT INTO CREATURE_HAS_TRAITS_JT (CREATURE_ID, TRAIT_ID) VALUES (2, 5);
INSERT INTO CREATURE_HAS_TRAITS_JT (CREATURE_ID, TRAIT_ID) VALUES (2, 6);
