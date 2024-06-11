// -- -------------------------------------------------------------------------------------- --
// -- SUBWAY: U1
// -- -------------------------------------------------------------------------------------- --
WITH [
    ["Leopoldau", 21, "Floridsdorf", "Wien", "Großfeldsiedlung", 21, "Floridsdorf","Wien", "U1", 1.8, 125],
    ["Großfeldsiedlung", 21, "Floridsdorf","Wien", "Aderklaaer Straße", 21, "Floridsdorf","Wien", "U1", 0.8, 58],
    ["Aderklaaer Straße", 21, "Floridsdorf","Wien", "Rennbahnweg", 22, "Donaustadt","Wien", "U1", 0.8, 55],
    ["Rennbahnweg", 22, "Donaustadt","Wien", "Kagraner Platz", 22, "Donaustadt","Wien", "U1", 2.2, 153],
    ["Kagraner Platz",22, "Donaustadt","Wien", "Kagran", 22, "Donaustadt","Wien","U1", 0.2, 24],
    ["Kagran",22, "Donaustadt","Wien", "Alte Donau",22, "Donaustadt","Wien", "U1", 1, 43],
    ["Alte Donau",22, "Donaustadt","Wien", "Kaisermühlen-VIC",22, "Donaustadt","Wien", "U1", 1.4, 107],
    ["Kaisermühlen-VIC",22, "Donaustadt","Wien", "Donauinsel", 2, "Leopoldstadt","Wien", "U1", 1.2, 54],
    ["Donauinsel", 2, "Leopoldstadt","Wien","Vorgartenstraße",2, "Leopoldstadt","Wien", "U1", 2.1, 123],
    ["Vorgartenstraße",2, "Leopoldstadt","Wien", "Praterstern",2, "Leopoldstadt","Wien", "U1", 1.1, 67],
    ["Praterstern",2, "Leopoldstadt", "Wien","Nestroyplatz",2, "Leopoldstadt","Wien", "U1", 1.1, 64],
    ["Nestroyplatz",2, "Leopoldstadt","Wien", "Schwedenplatz", 1, "Innere Stadt","Wien", "U1", 1.2, 71],
    ["Schwedenplatz", 1, "Innere Stadt","Wien","Stephansplatz", 1, "Innere Stadt","Wien","U1", 1.14, 52],
    ["Stephansplatz", 1, "Innere Stadt","Wien","Karlsplatz",1, "Innere Stadt","Wien", "U1", 2.02, 112],
    ["Karlsplatz",1, "Innere Stadt","Wien", "Taubstummengasse",4, "Wieden","Wien", "U1", 2.2, 132],
    ["Taubstummengasse", 4, "Wieden","Wien","Wien Hauptbahnhof",4, "Wieden","Wien", "U1", 1.86, 86],
    ["Wien Hauptbahnhof",4, "Wieden","Wien", "Keplerplatz",10, "Favoriten","Wien", "U1", 1.99, 99],
    ["Keplerplatz",10, "Favoriten","Wien", "Reumannplatz",10, "Favoriten","Wien", "U1", 1.87, 100],
    ["Reumannplatz",10, "Favoriten","Wien", "Troststraße",10, "Favoriten","Wien", "U1", 2.05, 120],
    ["Troststraße",10, "Favoriten","Wien", "Altes Landgut",10, "Favoriten","Wien", "U1", 1.55, 67],
    ["Altes Landgut",10, "Favoriten","Wien", "Alaudagasse",10, "Favoriten","Wien", "U1", 1.6, 86],
    ["Alaudagasse",10, "Favoriten","Wien", "Neulaa",10, "Favoriten","Wien", "U1", 1.9, 125],
    ["Neulaa",10, "Favoriten","Wien", "Oberlaa",10, "Favoriten","Wien", "U1", 2.2, 142]
] as data
UNWIND data as row
MERGE (s:Station {name: row[0], plz: row[1], district: row[2], state: row[3]})
MERGE (s1:Station {name: row[4], plz: row[5], district: row[6], state: row[7]})
MERGE (s)-[c:SUBWAY {code: row[8], length: row[9], time: row[10]}]->(s1)-[c1:SUBWAY {code: row[8], length: row[9], time: row[10]}]->(s);


// -- -------------------------------------------------------------------------------------- --
// -- SUBWAY: U2
// -- -------------------------------------------------------------------------------------- --
WITH [
    ["Seestadt", 22, "Donaustadt","Wien", "Aspern Nord",22, "Donaustadt","Wien", "U2",  2.0, 123],
    ["Aspern Nord",22, "Donaustadt","Wien", "Hausfeldstraße",22, "Donaustadt","Wien", "U2", 2.0, 121],
    ["Hausfeldstraße",22, "Donaustadt","Wien", "Aspernstraße",22, "Donaustadt","Wien", "U2",  1.1, 69],
    ["Aspernstraße",22, "Donaustadt","Wien", "Donauspital",22, "Donaustadt","Wien", "U2",  1.5, 79],
    ["Donauspital",22, "Donaustadt","Wien", "Hardeggasse",22, "Donaustadt","Wien", "U2", 1.1, 66],
    ["Hardeggasse",22, "Donaustadt","Wien", "Stadlau",22, "Donaustadt","Wien", "U2", 1.7, 101],
    ["Stadlau",22, "Donaustadt","Wien", "Donaustadtbrücke",22, "Donaustadt","Wien", "U2", 0.8, 45],
    ["Donaustadtbrücke",22, "Donaustadt","Wien", "Donaumarina",22, "Donaustadt","Wien", "U2",  2.1, 129],
    ["Donaumarina",22, "Donaustadt","Wien", "Stadion",2, "Leopoldstadt","Wien", "U2", 1.3, 76],
    ["Stadion",2, "Leopoldstadt","Wien", "Krieau",2, "Leopoldstadt","Wien", "U2", 2.0, 117],
    ["Krieau",2, "Leopoldstadt","Wien", "Messe-Prater",2, "Leopoldstadt","Wien", "U2",  1.1, 76],
    ["Messe-Prater",2, "Leopoldstadt","Wien", "Praterstern",2, "Leopoldstadt","Wien", "U2",  0.6, 55],
    ["Praterstern",2, "Leopoldstadt","Wien", "Taborstraße",2, "Leopoldstadt","Wien", "U2",  2.6, 144],
    ["Taborstraße",2, "Leopoldstadt","Wien", "Schottenring",1, "Innere Stadt","Wien", "U2", 2.3, 132],
    ["Schottenring",1, "Innere Stadt","Wien", "Schottentor",1, "Innere Stadt","Wien", "U2", 1.0, 67],
    ["Schottentor",1, "Innere Stadt","Wien", "Rathaus",1, "Innere Stadt","Wien", "U2", 1.6, 88],
    ["Rathaus",1, "Innere Stadt","Wien", "Volkstheater",7, "Neubau","Wien", "U2", 2.4, 152],
    ["Volkstheater",7, "Neubau","Wien",  "Museumsquartier",7, "Neubau","Wien", "U2", 1.7, 90],
    ["Museumsquartier",7, "Neubau","Wien", "Karlsplatz",1, "Innere Stadt","Wien", "U2", 2.2, 141]
] AS data
UNWIND data as row
MERGE (s:Station {name: row[0], plz: row[1], district: row[2], state: row[3]})
MERGE (s1:Station {name: row[4], plz: row[5], district: row[6], state: row[7]})
MERGE (s)-[c:SUBWAY {code: row[8], length: row[9], time: row[10]}]->(s1)-[c1:SUBWAY {code: row[8], length: row[9], time: row[10]}]->(s);



// -- -------------------------------------------------------------------------------------- --
// -- SUBWAY: U3
// -- -------------------------------------------------------------------------------------- --
with[
	["Ottakring", 16, "Ottakring", "Wien", "Kendlerstraße",16, "Ottakring","Wien", "U3", 1.5, 154],
	["Kendlerstraße",16, "Ottakring", "Wien","Hütteldorfer Straße",14, "Penzing","Wien", "U3", 1.2, 89],
	["Hütteldorfer Straße",14, "Penzing","Wien", "Johnstraße", 15, "Rudolfsheim-Fünfhaus","Wien", "U3", 0.9, 73],
	["Johnstraße",15, "Rudolfsheim-Fünfhaus", "Wien","Schweglerstraße",15, "Rudolfsheim-Fünfhaus", "Wien","U3", 1.5, 115],
	["Schweglerstraße",15, "Rudolfsheim-Fünfhaus","Wien", "Westbahnhof",15, "Rudolfsheim-Fünfhaus","Wien", "U3", 1.1, 84],
	["Westbahnhof",15, "Rudolfsheim-Fünfhaus","Wien", "Zieglergasse",7, "Neubau","Wien", "U3",  2.3, 166],
	["Zieglergasse",7, "Neubau","Wien", "Neubaugasse",7, "Neubau","Wien", "U3", 1.7, 130],
	["Neubaugasse",7, "Neubau", "Wien", "Volkstheater",7, "Neubau","Wien", "U3", 1.2, 100],
	["Volkstheater",7, "Neubau", "Wien","Herrengasse",1, "Innere Stadt","Wien", "U3", 1.2, 112],
	["Herrengasse",1, "Innere Stadt", "Wien","Stephansplatz",1, "Innere Stadt","Wien", "U3", 2.1, 171],
	["Stephansplatz",1, "Innere Stadt","Wien", "Stubentor",1, "Innere Stadt","Wien", "U3", 1.6, 143],
	["Stubentor",1, "Innere Stadt", "Wien","Landstraße",3, "Landstraße","Wien", "U3",  11, 9.8],
	["Landstraße",3, "Landstraße","Wien",  "Rochusgasse",3, "Landstraße", "Wien","U3",  0.6, 65],
	["Rochusgasse",3, "Landstraße", "Wien","Kardinal-Nagl-Platz",3, "Landstraße","Wien", "U3", 0.9, 86],
	["Kardinal-Nagl-Platz",3, "Landstraße","Wien", "Schlachthausgasse",3, "Landstraße","Wien", "U3", 1.3, 107],
	["Schlachthausgasse",3, "Landstraße", "Wien","Erdberg",3, "Landstraße","Wien", "U3", 1.0, 65],
	["Erdberg",3, "Landstraße", "Wien","Gasometer",11, "Simmering","Wien", "U3", 0.7, 50],
	["Gasometer",11, "Simmering", "Wien","Zipperstraße",11, "Simmering","Wien", "U3", 1.3, 77],
	["Zipperstraße",11, "Simmering", "Wien","Enkplatz",11, "Simmering", "Wien","U3",  2.0, 123],
	["Enkplatz",11, "Simmering", "Wien","Simmering",11, "Simmering","Wien", "U3", 1.3, 80]
] as data
UNWIND data as row
MERGE (s:Station {name: row[0], plz: row[1], district: row[2], state: row[3]})
MERGE (s1:Station {name: row[4], plz: row[5], district: row[6], state: row[7]})
MERGE (s)-[c:SUBWAY {code: row[8], length: row[9], time: row[10]}]->(s1)-[c1:SUBWAY {code: row[8], length: row[9], time: row[10]}]->(s);



// -- -------------------------------------------------------------------------------------- --
// -- SUBWAY: U4
// -- -------------------------------------------------------------------------------------- --
WITH [
	["Heiligenstadt",19, "Döbling","Wien", "Spittelau", 9, "Alsergrund","Wien", "U4", 2.9, 122],
	["Spittelau",9, "Alsergrund","Wien", "Friedensbrücke",9, "Alsergrund", "Wien","U4", 1.2, 69],
	["Friedensbrücke",9, "Alsergrund","Wien", "Roßauer Lände",9, "Alsergrund","Wien",  "U4", 1.1, 71],
	["Roßauer Lände",9, "Alsergrund","Wien", "Schottenring",1, "Innere Stadt","Wien", "U4", 1.7, 65],
	["Schottenring",1, "Innere Stadt","Wien", "Schwedenplatz",1, "Innere Stadt","Wien", "U4", 2.2, 125],
	["Schwedenplatz",1, "Innere Stadt","Wien", "Landstraße",3, "Landstraße","Wien", "U4", 2.4, 111],
	["Landstraße",3, "Landstraße","Wien", "Stadtpark",3, "Landstraße","Wien", "U4", 1.5, 62],
	["Stadtpark",3, "Landstraße","Wien", "Karlsplatz",1, "Innere Stadt", "Wien", "U4", 3, 131],
	["Karlsplatz",1, "Innere Stadt","Wien", "Kettenbrückengasse",5, "Margareten","Wien", "U4", 2.4, 117],
	["Kettenbrückengasse",5, "Margareten","Wien", "Pilgramgasse",5, "Margareten","Wien", "U4", 1.4, 61],
	["Pilgramgasse",5, "Margareten","Wien", "Margaretengürtel",5, "Margareten","Wien", "U4", 2.6, 123],
	["Margaretengürtel",5, "Margareten","Wien", "Längenfeldgasse", 12, "Meidling","Wien", "U4", 3.2, 129],
	["Längenfeldgasse",12, "Meidling","Wien", "Meidling Hauptstraße",12, "Meidling", "Wien","U4", 0.9, 58],
	["Meidling Hauptstraße",12, "Meidling","Wien", "Schönbrunn", 13, "Hietzing","Wien", "U4", 1.0, 67],
	["Schönbrunn",  13, "Hietzing","Wien","Hietzing", 13, "Hietzing","Wien", "U4", 2.3, 133],
	["Hietzing", 13, "Hietzing","Wien", "Braunschweiggasse", 13, "Hietzing","Wien", "U4", 1.3, 66],
	["Braunschweiggasse", 13, "Hietzing", "Wien","Unter St. Veit", 13, "Hietzing","Wien", "U4", 2.5, 113],
	["Unter St. Veit", 13, "Hietzing","Wien", "Ober St. Veit", 13, "Hietzing", "Wien","U4", 1.9, 55],
	["Ober St. Veit", 13, "Hietzing", "Wien","Hütteldorf", 14, "Penzing", "Wien","U4", 2.1, 124]
] as data
UNWIND data as row
MERGE (s:Station {name: row[0], plz: row[1], district: row[2], state: row[3]})
MERGE (s1:Station {name: row[4], plz: row[5], district: row[6], state: row[7]})
MERGE (s)-[c:SUBWAY {code: row[8], length: row[9], time: row[10]}]->(s1)-[c1:SUBWAY {code: row[8], length: row[9], time: row[10]}]->(s);


// -- -------------------------------------------------------------------------------------- --
// -- SUBWAY: U5
// -- -------------------------------------------------------------------------------------- --
WITH [
	["Hernals",17, "Hernals",  "Wien","Elterleinplatz", 17, "Hernals",  "Wien","U5", 1.5, 78],
	["Elterleinplatz",17, "Hernals", "Wien", "Michelbeuern AKH", 9, "Alsergrund", "Wien", "U5", 2.3, 123],
	["Michelbeuern AKH",9, "Alsergrund", "Wien", "Arne Karlsson-Platz", 9, "Alsergrund",  "Wien","U5", 1.2, 75],
	["Arne Karlsson-Platz",9, "Alsergrund", "Wien", "Frankhplatz", 9, "Alsergrund",  "Wien","U5", 0.8, 58],
	["Frankhplatz",9, "Alsergrund",  "Wien","Rathaus", 1, "Innere Stadt", "Wien", "U5", 0.7, 67],
	["Rathaus",1, "Innere Stadt",  "Wien","Volkstheater", 7, "Neubau",  "Wien","U5", 1.2, 71],
	["Volkstheater", 7, "Neubau",  "Wien","Museumsquartier", 7, "Neubau",  "Wien","U5", 1.5, 92],
	["Museumsquartier",7, "Neubau",  "Wien","Karlsplatz", 1, "Innere Stadt",  "Wien","U5", 0.9, 87]
] as data
UNWIND data as row
MERGE (s:Station {name: row[0], plz: row[1], district: row[2], state: row[3]})
MERGE (s1:Station {name: row[4], plz: row[5], district: row[6], state: row[7]})
MERGE (s)-[c:SUBWAY {code: row[8], length: row[9], time: row[10]}]->(s1)-[c1:SUBWAY {code: row[8], length: row[9], time: row[10]}]->(s);



// -- -------------------------------------------------------------------------------------- --
// -- SUBWAY: U6
// -- -------------------------------------------------------------------------------------- --
WITH [
    ["Siebenhirten",23, "Liesing","Wien", "Perfektastraße",23, "Liesing","Wien", "U6", 0.6, 64],
    ["Perfektastraße",23, "Liesing", "Wien","Erlaaer Straße",23, "Liesing","Wien", "U6", 0.4, 47],
    ["Erlaaer Straße",23, "Liesing", "Wien","Alterlaa",23, "Liesing","Wien", "U6", 1.2, 108],
    ["Alterlaa",23, "Liesing","Wien", "Am Schöpfwerk", 12, "Meidling","Wien","U6", 1.0, 127],
    ["Am Schöpfwerk",12, "Meidling","Wien", "Tscherttegasse",12, "Meidling","Wien", "U6", 0.5, 62],
    ["Tscherttegasse",12, "Meidling", "Wien","Wien Meidling",12, "Meidling","Wien", "U6", 1.1, 130],
    ["Wien Meidling",12, "Meidling", "Wien","Niederhofstraße",12, "Meidling", "Wien","U6", 1.4, 128],
    ["Niederhofstraße",12, "Meidling","Wien", "Längenfeldgasse",12, "Meidling","Wien", "U6", 0.3, 57],
    ["Längenfeldgasse",12, "Meidling","Wien","Gumpendorfer Straße",6, "Mariahilf","Wien", "U6", 1.2, 129],
    ["Gumpendorfer Straße",6, "Mariahilf","Wien","Westbahnhof",15, "Rudolfsheim-Fünfhaus","Wien", "U6",0.4, 75],
    ["Westbahnhof",15, "Rudolfsheim-Fünfhaus","Wien", "Burggasse-Stadthalle",3,"Landstraße","Wien", "U6",1.4, 115],
    ["Burggasse-Stadthalle", 3, "Landstraße","Wien","Thaliastraße",16, "Ottakring","Wien", "U6",0.2, 64],
    ["Thaliastraße",16, "Ottakring","Wien","Josefstädter Straße",16, "Ottakring", "Wien","U6",1.2, 108],
    ["Josefstädter Straße",16, "Ottakring","Wien","Alser Straße",16, "Ottakring","Wien", "U6",1.3, 128],
    ["Alser Straße",16, "Ottakring","Wien","Michelbeuern AKH",9, "Alsergrund","Wien", "U6",0.5, 52],
    ["Michelbeuern AKH",9, "Alsergrund","Wien","Währinger Straße-Volksoper",9, "Alsergrund", "Wien","U6",1.0, 115],
    ["Währinger Straße-Volksoper",9, "Alsergrund","Wien", "Nußdorfer Straße",9, "Alsergrund","Wien", "U6",0.4, 56],
    ["Nußdorfer Straße",9, "Alsergrund","Wien","Spittelau",9, "Alsergrund","Wien", "U6",1.3, 132],
    ["Spittelau",9, "Alsergrund", "Wien","Jägerstraße", 20, "Brigittenau","Wien", "U6",0.6, 50],
    ["Jägerstraße",20, "Brigittenau", "Wien","Dresdner Straße",20, "Brigittenau","Wien", "U6",0.7, 69],
    ["Dresdner Straße",20, "Brigittenau","Wien","Handelskai",20, "Brigittenau","Wien", "U6",0.4, 68],
    ["Handelskai",20, "Brigittenau","Wien","Neue Donau",21, "Floridsdorf", "Wien","U6",0.5, 66],
    ["Neue Donau",21, "Floridsdorf","Wien","Floridsdorf",21, "Floridsdorf","Wien", "U6",1.2, 117]
] as data
UNWIND data as row
MERGE (s:Station {name: row[0], plz: row[1], district: row[2], state: row[3]})
MERGE (s1:Station {name: row[4], plz: row[5], district: row[6], state: row[7]})
MERGE (s)-[c:SUBWAY {code: row[8], length: row[9], time: row[10]}]->(s1)-[c1:SUBWAY {code: row[8], length: row[9], time: row[10]}]->(s);



// -- -------------------------------------------------------------------------------------- --
// -- TRAMWAY: D
// -- -------------------------------------------------------------------------------------- --
WITH [
	["Quartier Belvedere",4, "Wieden","Wien","Wien Hauptbahnhof",4, "Wieden","Wien","D",3.4, 300],
	["Wien Hauptbahnhof",4, "Wieden","Wien","Columbusplatz",10,"Favoriten", "Wien","D",5.1, 340],
	["Columbusplatz",10,"Favoriten", "Wien","Schloss Belvedere",3,"Landstraße","Wien","D",4.8, 410],
	["Schloss Belvedere",3,"Landstraße","Wien","Gußhausstraße",4,"Wieden","Wien","D",3.4, 280],
	["Gußhausstraße",4,"Wieden","Wien", "Schwarzenbergplatz",3,"Landstraße","Wien","D",3.2, 320],
	["Schwarzenbergplatz",3,"Landstraße","Wien","Kärtner Ring",1,"Innere Stadt","Wien","D",4.2, 410],
	["Kärtner Ring",1,"Innere Stadt","Wien","Burgring", 1, "Innere Stadt", "Wien", "D",3.1, 340],
	["Burgring", 1, "Innere Stadt", "Wien","Rathaus",1, "Innere Stadt","Wien","D",4.1, 280],
	["Rathaus",1, "Innere Stadt","Wien","Schottenring",1, "Innere Stadt","Wien", "D",3.2, 310],
	["Schottenring",1, "Innere Stadt","Wien","Börse", 1,"Innere Stadt","Wien","D",2.4, 210],
	["Börse", 1,"Innere Stadt","Wien","Franz-Josef Bahnhof", 9,"Alsergrund", "Wien","D",4.3, 410],
	["Franz-Josef Bahnhof", 9,"Alsergrund", "Wien","Spittelau", 9, "Alsergrund","Wien","D", 1.8, 310],
	["Spittelau", 9,"Alsergrund", "Wien","Heiligenstadt", 19, "Döbling","Wien","D", 2.5, 310],
	["Heiligenstadt", 19, "Döbling","Wien","Nußdorfer Straße",9, "Alsergrund","Wien","D", 5.5, 510]
] AS data
UNWIND data as row
MERGE (s:Station {name: row[0], plz: row[1], district: row[2], state: row[3]})
MERGE (s1:Station {name: row[4], plz: row[5], district: row[6], state: row[7]})
MERGE (s)-[c:TRAMWAY {code: row[8], length: row[9], time: row[10]}]->(s1)-[c1:TRAMWAY {code: row[8], length: row[9], time: row[10]}]->(s);

// -- -------------------------------------------------------------------------------------- --
// -- TRAMWAY: O
// -- -------------------------------------------------------------------------------------- --
WITH [
	["Praterstern",2, "Leopoldstadt","Wien","Radetzkyplatz",2, "Leopoldau", "Wien","O",5.1, 410],
	["Radetzkyplatz",2, "Leopoldau", "Wien","Hintere Zollamtsstraße",3,"Landstraße","Wien","O",4.8, 370],
	["Hintere Zollamtsstraße",3,"Landstraße","Wien","Marxergasse",3,"Landstraße","Wien", "O",3.2, 280],
	["Marxergasse",3,"Landstraße","Wien","Landstraße",3, "Landstraße","Wien","O",2.1, 180],
	["Landstraße",3, "Landstraße","Wien","Sechskrügelgasse", 3,"Landstraße", "Wien","O",3.1, 240],
	["Sechskrügelgasse", 3,"Landstraße", "Wien","Rennweg",3, "Landstraße","Wien","O",2.5, 230],
	["Rennweg",3, "Landstraße","Wien","Kölblgasse",3,"Landstraße","Wien","O",2.1, 190],
	["Kölblgasse",3,"Landstraße","Wien","Quartier Belvedere",4, "Wieden","Wien","O",3.2, 250],
	["Quartier Belvedere",4, "Wieden","Wien","Wien Hauptbahnhof",4, "Wieden","Wien","O",4.5,490],
	["Wien Hauptbahnhof",4, "Wieden","Wien","Laxenburger Straße",10,"Favoriten","Wien","O",3.2, 210],
	["Laxenburger Straße",10,"Favoriten","Wien","Raxstraße",10, "Favoriten","Wien","O",4.2, 350]
] AS data
UNWIND data as row
MERGE (s:Station {name: row[0], plz: row[1], district: row[2], state: row[3]})
MERGE (s1:Station {name: row[4], plz: row[5], district: row[6], state: row[7]})
MERGE (s)-[c:TRAMWAY {code: row[8], length: row[9], time: row[10]}]->(s1)-[c1:TRAMWAY {code: row[8], length: row[9], time: row[10]}]->(s);

// -- -------------------------------------------------------------------------------------- --
// -- TRAMWAY: 1
// -- -------------------------------------------------------------------------------------- --
WITH [
	["Praterstern",2, "Leopoldstadt","Wien","Radetzkyplatz",2, "Leopoldau", "Wien","1",5.1, 410],
	["Radetzkyplatz",2, "Leopoldau", "Wien","Hintere Zollamtsstraße",3,"Landstraße","Wien","1",4.8, 370],
	["Hintere Zollamtsstraße",3,"Landstraße","Wien","Julius-Raab-Platz",1,"Innere Stadt","Wien", "1",3.2, 280],
	["Julius-Raab-Platz",1,"Innere Stadt","Wien","Schwedenplatz", 1, "Innere Stadt","Wien","1",2.8, 210],
	["Schwedenplatz",1,"Innere Stadt","Wien","Schottenring",1, "Innere Stadt","Wien","1",3.2, 260],
	["Schottenring",1, "Innere Stadt","Wien","Börse", 1,"Innere Stadt","Wien","1",2.1, 230],
	["Börse", 1,"Innere Stadt","Wien","Schottentor", 1, "Innere Stadt", "Wien","1",2.7, 250],
	["Schottentor", 1, "Innere Stadt", "Wien","Rathaus",1, "Innere Stadt","Wien","1",3.4, 320],
	["Rathaus",1, "Innere Stadt","Wien","Burgring", 1, "Innere Stadt", "Wien","1",2.5, 270],
	["Burgring", 1, "Innere Stadt", "Wien","Kärtner Ring",1,"Innere Stadt","Wien","1",4.1, 280],
	["Kärtner Ring",1,"Innere Stadt","Wien","Karlsplatz",1, "Innere Stadt","Wien","1",2.2, 180],
	["Karlsplatz",1, "Innere Stadt","Wien","Resselgasse",4,"Wieden","Wien","1",1.6, 130],
	["Resselgasse",4,"Wieden","Wien","Matzleinsdorfer Platz",10,"Favoriten","Wien","1", 2.6, 230],
	["Matzleinsdorfer Platz",10,"Favoriten","Wien","Stefan-Fadinger-Platz",10,"Favoriten","Wien","1",5.2, 480]
] AS data
UNWIND data as row
MERGE (s:Station {name: row[0], plz: row[1], district: row[2], state: row[3]})
MERGE (s1:Station {name: row[4], plz: row[5], district: row[6], state: row[7]})
MERGE (s)-[c:TRAMWAY {code: row[8], length: row[9], time: row[10]}]->(s1)-[c1:TRAMWAY {code: row[8], length: row[9], time: row[10]}]->(s);

// -- -------------------------------------------------------------------------------------- --
// -- TRAMWAY: 2
// -- -------------------------------------------------------------------------------------- --
WITH [
	["Ottakring", 16, "Ottakring","Wien", "Johann-Nepomuk-Platz", 16,"Ottakring","Wien","2",5.3, 480],
	["Johann-Nepomuk-Platz", 16,"Ottakring","Wien","Brunnengasse", 16, "Ottakring","Wien","2",3.8, 360],
	["Brunnengasse", 16, "Ottakring","Wien","Josefstädter Straße",16, "Ottakring", "Wien","2",3.1, 260],
	["Josefstädter Straße", 16, "Ottakring","Wien","Blindengasse",8,"Josefstadt","Wien","2",3.4, 340],
	["Blindengasse",8,"Josefstadt","Wien","Rathaus",1, "Innere Stadt","Wien","2",5.3, 470],
	["Rathaus",1, "Innere Stadt","Wien","Burgring", 1, "Innere Stadt", "Wien","2",3.5, 270],
	["Burgring", 1, "Innere Stadt", "Wien","Kärtner Ring",1,"Innere Stadt","Wien","2",3.1, 340],
	["Kärtner Ring",1,"Innere Stadt","Wien","Schwarzenbergplatz",3,"Landstraße","Wien","2",4.2, 410],
	["Schwarzenbergplatz",3,"Landstraße","Wien","Stubentor",1, "Innere Stadt","Wien","2",3.1, 260],
	["Stubentor",1, "Innere Stadt","Wien","Julius-Raab-Platz",1,"Innere Stadt","Wien","2",2.1, 210],
	["Julius-Raab-Platz",1,"Innere Stadt","Wien","Schwedenplatz", 1, "Innere Stadt","Wien","2",2.1, 210],
	["Schwedenplatz", 1, "Innere Stadt","Wien","Karmeliterplatz",1,"Innere Stadt","Wien","2",3.4, 290],
	["Karmeliterplatz",1,"Innere Stadt","Wien","Taborstraße",2, "Leopoldstadt","Wien","2",4.3, 310],
	["Taborstraße",2, "Leopoldstadt","Wien","Am Tabor",2,"Leopoldstadt","Wien","2",2.6, 290],
	["Am Tabor",2,"Leopoldstadt","Wien","Traisengasse", 20, "Brigittenau","Wien","2",3.5, 320],
	["Traisengasse", 20, "Brigittenau","Wien","Dresdner Straße",20, "Brigittenau","Wien","2",4.1, 330]
] AS data
UNWIND data as row
MERGE (s:Station {name: row[0], plz: row[1], district: row[2], state: row[3]})
MERGE (s1:Station {name: row[4], plz: row[5], district: row[6], state: row[7]})
MERGE (s)-[c:TRAMWAY {code: row[8], length: row[9], time: row[10]}]->(s1)-[c1:TRAMWAY {code: row[8], length: row[9], time: row[10]}]->(s);

// -- -------------------------------------------------------------------------------------- --
// -- TRAMWAY: 5
// -- -------------------------------------------------------------------------------------- --
WITH [
	["Praterstern",2, "Leopoldstadt","Wien","Nordbahnstraße",2,"Leopoldstadt","Wien","5",2.2, 180],
	["Nordbahnstraße",2,"Leopoldstadt","Wien","Am Tabor",2,"Leopoldstadt","Wien","5",3.5, 240],
	["Am Tabor",2,"Leopoldstadt","Wien","Nordwestbahnstraße", 2,"Leopoldstadt","Wien","5",5.0,320],
	["Nordwestbahnstraße", 2,"Leopoldstadt","Wien","Wallensteinplatz",20,"Liesing","Wien","5",3.3,280],
	["Wallensteinplatz",20,"Liesing","Wien","Klosterneuburger Straße", 20, "Liesing","Wien","5",2.5,220],
	["Klosterneuburger Straße", 20, "Liesing","Wien","Friedensbrücke",9, "Alsergrund","Wien","5",2.1,250],
	["Friedensbrücke",9, "Alsergrund","Wien","Franz-Josef Bahnhof", 9,"Alsergrund", "Wien","5",2.4, 190],
	["Franz-Josef Bahnhof", 9,"Alsergrund", "Wien","Nußdorfer Straße",9,"Alsergrund","Wien","5",3.7,280],
	["Nußdorfer Straße",9,"Alsergrund","Wien","Währinger Straße",9,"Alsergrund","Wien","5",2.6,210],
	["Währinger Straße",9,"Alsergrund","Wien","Michelbeuern AKH",9, "Alsergrund", "Wien","5",3.2,280],
	["Michelbeuern AKH",9, "Alsergrund", "Wien","Albertgasse",8,"Josefstadt","Wien","5",3.6,300],
	["Albertgasse",8,"Josefstadt","Wien","Blindengasse",8,"Josefstadt","Wien","5",5.0,520],
	["Blindengasse",8,"Josefstadt","Wien","Burggasse",8,"Rudolfsheim-Fünfhaus","Wien","5",2.5,230],
	["Burggasse",8,"Rudolfsheim-Fünfhaus","Wien","Westbahnstraße",8,"Rudolfsheim-Fünfhaus","Wien","5",2.7,250],
	["Westbahnstraße",8,"Rudolfsheim-Fünfhaus","Wien","Westbahnhof",15, "Rudolfsheim-Fünfhaus","Wien","5",1.8,200]
] AS data
UNWIND data as row
MERGE (s:Station {name: row[0], plz: row[1], district: row[2], state: row[3]})
MERGE (s1:Station {name: row[4], plz: row[5], district: row[6], state: row[7]})
MERGE (s)-[c:TRAMWAY {code: row[8], length: row[9], time: row[10]}]->(s1)-[c1:TRAMWAY {code: row[8], length: row[9], time: row[10]}]->(s);

// -- -------------------------------------------------------------------------------------- --
// -- TRAMWAY: 42
// -- -------------------------------------------------------------------------------------- --
WITH [
 ["Schottentor", 1, "Innere Stadt", "Wien","Schwarzspanierstraße",9, "Alsergrund", "Wien", "42", 0.2, 120],
 ["Schwarzspanierstraße", 9, "Alsergrund", "Wien", "Spitalgasse",9, "Alsergrund", "Wien", "42", 1.5, 360],
 ["Spitalgasse",9, "Alsergrund", "Wien", "Volkstheater",7, "Neubau", "Wien", "42", 1.6, 360],
 ["Volkstheater",7, "Neubau", "Wien","Michelbeuern AKH",9, "Alsergrund", "Wien", "42", 0.8, 180],
 ["Michelbeuern AKH",9, "Alsergrund", "Wien", "Eduardgasse",8, "Josefstadt","Wien", "42", 1.3, 540],
 ["Eduardgasse",8, "Josefstadt","Wien", "Johann-Nepomuk-Vogl-Platz",8, "Josefstadt","Wien", "42", 0.4, 240],
 ["Johann-Nepomuk-Vogl-Platz",8, "Josefstadt","Wien","Vizenzgasse",8, "Josefstadt","Wien", "42", 0.8, 300],
 ["Vizenzgasse",8, "Josefstadt","Wien", "Sommarugagasse", 18, "Währing", "Wien", "42", 0.6, 300],
 ["Sommarugagasse", 18, "Währing", "Wien", "Antonigasse", 18, "Währing", "Wien", "42", 0.6, 300]
] as data
UNWIND data as row
MERGE (s:Station {name: row[0], plz: row[1], district: row[2], state: row[3]})
MERGE (s1:Station {name: row[4], plz: row[5], district: row[6], state: row[7]})
MERGE (s)-[c:TRAMWAY {code: row[8], length: row[9], time: row[10]}]->(s1)-[c1:TRAMWAY {code: row[8], length: row[9], time: row[10]}]->(s);

// -- -------------------------------------------------------------------------------------- --
// -- TRAMWAY: 52
// -- -------------------------------------------------------------------------------------- --
WITH [
   ["Westbahnhof",15, "Rudolfsheim-Fünfhaus","Wien", "Staglgasse",15, "Rudolfsheim-Fünfhaus", "Wien", "52", 0.180, 55],
   ["Staglgasse", 15, "Rudolfsheim-Fünfhaus", "Wien","Mariahilfer Straße, Geibelgasse", 15, "Rudolfsheim-Fünfhaus", "Wien","52", 0.400, 150],
   ["Mariahilfer Straße, Geibelgasse",15, "Rudolfsheim-Fünfhaus", "Wien","Rustengasse",15, "Rudolfsheim-Fünfhaus", "Wien", "52", 0.270, 72],
   ["Rustengasse",15, "Rudolfsheim-Fünfhaus", "Wien","Anschützgasse",15, "Rudolfsheim-Fünfhaus", "Wien", "52", 0.400, 60],
   ["Anschützgasse",15, "Rudolfsheim-Fünfhaus", "Wien","Winckelmannstraße",15, "Rudolfsheim-Fünfhaus", "Wien", "52", 0.170, 54],
   ["Winckelmannstraße",15, "Rudolfsheim-Fünfhaus", "Wien","Penzinger Straße",14, "Penzing","Wien", "52", 0.500, 56],
   ["Penzinger Straße",14, "Penzing","Wien","Johnstraße",14, "Penzing","Wien","52", 0.400, 153],
   ["Johnstraße",14, "Penzing","Wien","Reinlgasse",14, "Penzing","Wien", "52", 0.350, 55],
   ["Reinlgasse",14, "Penzing","Wien","Diesterweggasse", 4, "Wieden","Wien","52", 0.500, 54],
   ["Diesterweggasse", 4, "Wieden","Wien","Ameisgasse",  4, "Wieden","Wien","52", 0.550, 54],
   ["Ameisgasse", 4, "Wieden","Wien","Lützowgasse",  4, "Wieden","Wien","52", 0.550, 134],
   ["Lützowgasse", 4, "Wieden","Wien","Gusenleithnergasse", 4, "Wieden","Wien", "52", 0.400, 79],
   ["Gusenleithnergasse", 4, "Wieden","Wien","Zehetnergasse", 4, "Wieden","Wien", "52", 0.270, 78],
   ["Zehetnergasse", 4, "Wieden","Wien","Gruschaplatz", 4, "Wieden","Wien", "52", 0.270, 56],
   ["Gruschaplatz", 4, "Wieden","Wien","Hochsatzengasse", 14, "Penzing","Wien", "52", 0.450, 127],
   ["Hochsatzengasse",14, "Penzing","Wien","Baumgarten",14, "Penzing","Wien", "52", 0.450, 73]

] as data
UNWIND data as row
MERGE (s:Station {name: row[0], plz: row[1], district: row[2], state: row[3]})
MERGE (s1:Station {name: row[4], plz: row[5], district: row[6], state: row[7]})
MERGE (s)-[c:TRAMWAY {code: row[8], length: row[9], time: row[10]}]->(s1)-[c1:TRAMWAY {code: row[8], length: row[9], time: row[10]}]->(s);

// -- -------------------------------------------------------------------------------------- --
// -- EXPRESSWAY: S1
// -- -------------------------------------------------------------------------------------- --
WITH [
	["Marchegg", 2230,"Gänsendorf", "Niederösterreich","Gänsendorf", 2230, "Gänsendorf","Niederösterreich","S1",14.5, 2100],
	["Gänsendorf", 2230,"Gänsendorf", "Niederösterreich","Leopoldau", 21, "Floridsdorf","Wien","S1", 21, 1700],
	["Leopoldau",21, "Floridsdorf","Wien","Siemensstraße",21, "Floridsdorf","Wien","S1",4.4,380],
	["Siemensstraße",21, "Floridsdorf","Wien","Floridsdorf",21, "Floridsdorf","Wien","S1",5.1,480],
	["Floridsdorf",21, "Floridsdorf","Wien","Handelskai",20, "Brigittenau","Wien","S1",4.5,510],
	["Handelskai",20, "Brigittenau","Wien","Traisengasse", 20, "Brigittenau","Wien","S1",3.1,270],
	["Traisengasse", 20, "Brigittenau","Wien","Praterstern",2, "Leopoldstadt","Wien","S1",4.5,380],
	["Praterstern",2, "Leopoldstadt","Wien","Wien Mitte",3, "Landstraße","Wien","S1",6.5,650],
	["Wien Mitte",3, "Landstraße","Wien","Rennweg",3, "Landstraße","Wien","S1",7.2,720],
	["Rennweg",3, "Landstraße","Wien","Quartier Belvedere",4, "Wieden","Wien","S1",3.2,350],
	["Quartier Belvedere",4, "Wieden","Wien","Wien Hauptbahnhof",4, "Wieden","Wien","S1",4.5,450],
	["Wien Hauptbahnhof",4, "Wieden","Wien","Matzleinsdorfer Platz",10,"Favoriten","Wien","S1",5.6,520],
	["Matzleinsdorfer Platz",10,"Favoriten","Wien","Wien Meidling",12, "Meidling","Wien","S1",6.2,550]
] AS data
UNWIND data as row
MERGE (s:Station {name: row[0], plz: row[1], district: row[2], state: row[3]})
MERGE (s1:Station {name: row[4], plz: row[5], district: row[6], state: row[7]})
MERGE (s)-[c:EXPRESSWAY {code: row[8], length: row[9], time: row[10]}]->(s1)-[c1:EXPRESSWAY {code: row[8], length: row[9], time: row[10]}]->(s);

// -- -------------------------------------------------------------------------------------- --
// -- EXPRESSWAY: S2
// -- -------------------------------------------------------------------------------------- --
WITH [
	["Laa an der Thaya", 2136,"Mistelbach", "Niederösterreich","Mistelbach", 2130, "Mistelbach","Niederösterreich","S2",15.2, 1220],
	["Mistelbach", 2130, "Mistelbach","Niederösterreich","Wolkersdorf", 2120,"Wolkersdorf","Niederösterreich","S2", 17.3, 1320],
	["Wolkersdorf", 2120,"Wolkersdorf","Niederösterreich", "Kapellerfeld",2201, "Korneuburg","Niederösterreich","S2",10.5, 950],
	["Kapellerfeld",2201, "Korneuburg","Niederösterreich","Gerasdorf",2201, "Korneuburg","Niederösterreich","S2",2.5,300],
	["Gerasdorf",2201, "Korneuburg","Niederösterreich","Leopoldau",21, "Floridsdorf","Wien","S2",4.6,410],
	["Leopoldau",21, "Floridsdorf","Wien","Siemensstraße",21, "Floridsdorf","Wien","S2",4.4,380],
	["Siemensstraße",21, "Floridsdorf","Wien","Floridsdorf",21, "Floridsdorf","Wien","S2",5.1,480],
	["Floridsdorf",21, "Floridsdorf","Wien","Handelskai",20, "Brigittenau","Wien","S2",4.5,510],
	["Handelskai",20, "Brigittenau","Wien","Traisengasse", 20, "Brigittenau","Wien","S2",3.1,270],
	["Traisengasse", 20, "Brigittenau","Wien","Praterstern",2, "Leopoldstadt","Wien","S2",4.5,380],
	["Praterstern",2, "Leopoldstadt","Wien","Wien Mitte",3, "Landstraße","Wien","S2",6.5,650],
	["Wien Mitte",3, "Landstraße","Wien","Rennweg",3, "Landstraße","Wien","S2",7.2,720],
	["Rennweg",3, "Landstraße","Wien","Quartier Belvedere",4, "Wieden","Wien","S2",3.2,350],
	["Quartier Belvedere",4, "Wieden","Wien","Wien Hauptbahnhof",4, "Wieden","Wien","S2",4.5,450],
	["Wien Hauptbahnhof",4, "Wieden","Wien","Matzleinsdorfer Platz",10,"Favoriten","Wien","S2",5.6,520],
	["Matzleinsdorfer Platz",10,"Favoriten","Wien","Wien Meidling",12, "Meidling","Wien","S2",6.2,550],
	["Wien Meidling",12, "Meidling","Wien","Liesing",23,"Liesing","Wien","S2",5.2,480],
	["Liesing",23,"Liesing","Wien","Brunn-Maria Enzensdorf",2340,"Mödling","Niederösterreich","S2",6.5,650],
	["Brunn-Maria Enzensdorf",2340,"Mödling","Niederösterreich","Gumpoldskirchen",2340,"Mödling","Niederösterreich","S2",7.5,670],
	["Gumpoldskirchen",2340,"Mödling","Niederösterreich","Baden",2500,"Baden","Niederösterreich","S2",8.5,850],
	["Baden",2500,"Baden","Niederösterreich","Bad Vöslau",2500,"Baden","Niederösterreich","S2",10.3,950],
	["Bad Vöslau",2500,"Baden","Niederösterreich","Leobersdorf",2500,"Baden","Niederösterreich","S2",8.0,720],
	["Leobersdorf",2500,"Baden","Niederösterreich","Felixdorf",2700,"Wiener Neustadt","Niederösterreich","S2",5.7,600],
	["Felixdorf",2700,"Wiener Neustadt","Niederösterreich","Theresienfeld",2700,"Wiener Neustadt","Niederösterreich","S2",5.3,500],
	["Theresienfeld",2700,"Wiener Neustadt","Niederösterreich","Wiener Neustadt Nord",2700,"Wiener Neustadt","Niederösterreich","S2",5,520],
	["Wiener Neustadt Nord",2700,"Wiener Neustadt","Niederösterreich","Wiener Neustadt Hauptbahnhof",2700,"Wiener Neustadt","Niederösterreich","S2",2,200]
] AS data
UNWIND data as row
MERGE (s:Station {name: row[0], plz: row[1], district: row[2], state: row[3]})
MERGE (s1:Station {name: row[4], plz: row[5], district: row[6], state: row[7]})
MERGE (s)-[c:EXPRESSWAY {code: row[8], length: row[9], time: row[10]}]->(s1)-[c1:EXPRESSWAY {code: row[8], length: row[9], time: row[10]}]->(s);


// -- -------------------------------------------------------------------------------------- --
// -- EXPRESSWAY: S3
// -- -------------------------------------------------------------------------------------- --
WITH [
	["Hollabrunn", 2020,"Hollabrunn","Niederösterreich","Stockerau", 2201,"Korneuburg","Niederösterreich","S3",10.3,720],
	["Stockerau", 2201, "Korneuburg","Niederösterreich", "Korneuburg", 2201, "Korneuburg", "Niederösterreich","S3",14.2, 710],
	["Korneuburg", 2201,"Korneuburg", "Niederösterreich", "Bisamberg", 2201, "Korneuburg", "Niederösterreich","S3",5.1, 450],
	["Bisamberg",2201, "Korneuburg", "Niederösterreich", "Floridsdorf", 21, "Floridsdorf", "Wien","S3",10.2,710],
	["Floridsdorf",21, "Floridsdorf","Wien","Handelskai",20, "Brigittenau","Wien","S3",4.5,510],
	["Handelskai",20, "Brigittenau","Wien","Traisengasse", 20, "Brigittenau","Wien","S3",3.1,270],
	["Traisengasse", 20, "Brigittenau","Wien","Praterstern",2, "Leopoldstadt","Wien","S3",4.5,380],
	["Praterstern",2, "Leopoldstadt","Wien","Wien Mitte",3, "Landstraße","Wien","S3",6.5,650],
	["Wien Mitte",3, "Landstraße","Wien","Rennweg",3, "Landstraße","Wien","S3",7.2,720],
	["Rennweg",3, "Landstraße","Wien","Quartier Belvedere",4, "Wieden","Wien","S3",3.2,350],
	["Quartier Belvedere",4, "Wieden","Wien","Wien Hauptbahnhof",4, "Wieden","Wien","S3",4.5,450],
	["Wien Hauptbahnhof",4, "Wieden","Wien","Matzleinsdorfer Platz",10,"Favoriten","Wien","S3",5.6,520],
	["Matzleinsdorfer Platz",10,"Favoriten","Wien","Wien Meidling",12, "Meidling","Wien","S3",6.2,550],
	["Wien Meidling", 12, "Meidling", "Wien", "Ebreichsdorf", 2500,"Baden","Niederösterreich", "S3", 21.3, 818],
	["Ebreichsdorf", 2500,"Baden","Niederösterreich","Wiener Neustadt Hauptbahnhof", 2700, "Wiener Neustadt", "Niederösterreich", "S3", 14.2, 560]
] AS data
UNWIND data as row
MERGE (s:Station {name: row[0], plz: row[1], district: row[2], state: row[3]})
MERGE (s1:Station {name: row[4], plz: row[5], district: row[6], state: row[7]})
MERGE (s)-[c:EXPRESSWAY {code: row[8], length: row[9], time: row[10]}]->(s1)-[c1:EXPRESSWAY {code: row[8], length: row[9], time: row[10]}]->(s);



// -- -------------------------------------------------------------------------------------- --
// -- EXPRESSWAY: S40
// -- -------------------------------------------------------------------------------------- --
WITH [
	["Franz-Josef Bahnhof", 9,"Alsergrund", "Wien","Spittelau", 9, "Alsergrund","Wien","S40", 1.8, 150],
	["Spittelau", 9,"Alsergrund", "Wien","Heiligenstadt", 19, "Döbling","Wien","S40", 2.5, 250],
	["Heiligenstadt", 19,"Döbling", "Wien","Nußdorf", 19, "Döbling","Wien","S40", 3.2, 240],
	["Nußdorf", 19,"Döbling", "Wien","Klosterneuburg", 3400, "Klosterneuburg","Niederösterreich","S40", 10.3, 350],
	["Klosterneuburg", 3400,"Klosterneuburg", "Niederösterreich","St.Andrä-Wördern", 3430, "Tulln","Niederösterreich","S40", 15.2, 800],
	["St.Andrä-Wördern", 3430,"Tulln", "Niederösterreich","Tulln a.d. Donau", 3430, "Tulln","Niederösterreich","S40", 12.0, 780],
	["Tulln a.d. Donau", 3430,"Tulln", "Niederösterreich","Tulln Stadt", 3430, "Tulln","Niederösterreich","S40", 4.1, 300],
	["Tulln Stadt", 3430,"Tulln", "Niederösterreich","Tullnerfeld", 3430, "Tulln","Niederösterreich","S40", 14.7, 670],
	["Tullnerfeld", 3430,"Tulln", "Niederösterreich","Traismauer", 3100, "St.Pölten","Niederösterreich","S40", 18.3, 720],
	["Traismauer", 3100,"St.Pölten", "Niederösterreich","Herzogenburg", 3100, "St.Pölten","Niederösterreich","S40", 12.1, 600],
	["Herzogenburg", 3100,"St.Pölten", "Niederösterreich","St.Pölten Hauptbahnhof", 3100, "St.Pölten","Niederösterreich","S40", 15.1, 570]
] AS data
UNWIND data as row
MERGE (s:Station {name: row[0], plz: row[1], district: row[2], state: row[3]})
MERGE (s1:Station {name: row[4], plz: row[5], district: row[6], state: row[7]})
MERGE (s)-[c:EXPRESSWAY {code: row[8], length: row[9], time: row[10]}]->(s1)-[c1:EXPRESSWAY {code: row[8], length: row[9], time: row[10]}]->(s);


// -- -------------------------------------------------------------------------------------- --
// -- EXPRESSWAY: S45
// -- -------------------------------------------------------------------------------------- --
WITH [
	["Handelskai", 20,"Brigittenau", "Wien","Heiligenstadt", 19, "Döbling","Wien","S45", 4.5, 360],
	["Heiligenstadt", 19,"Döbling", "Wien","Oberdöbling", 19, "Döbling","Wien","S45", 3.2, 280],
	["Oberdöbling", 19,"Döbling", "Wien","Krottenbachstrasse", 19, "Döbling","Wien","S45", 4.2, 380],
	["Krottenbachstrasse", 19,"Döbling", "Wien","Gersthof", 18, "Währing","Wien","S45", 3.1, 310],
	["Gersthof", 18,"Währing", "Wien","Hernals", 17, "Hernals","Wien","S45", 4.5, 380],
	["Hernals", 17,"Hernals", "Wien","Ottakring", 16, "Ottakring","Wien","S45", 3.2, 280],
	["Ottakring", 16,"Ottakring", "Wien","Breitensee", 14, "Penzing","Wien","S45", 3.7, 410],
	["Breitensee", 14,"Penzing", "Wien","Hütteldorf", 14, "Penzing","Wien","S45", 4.1, 370]
] AS data
UNWIND data as row
MERGE (s:Station {name: row[0], plz: row[1], district: row[2], state: row[3]})
MERGE (s1:Station {name: row[4], plz: row[5], district: row[6], state: row[7]})
MERGE (s)-[c:EXPRESSWAY {code: row[8], length: row[9], time: row[10]}]->(s1)-[c1:EXPRESSWAY {code: row[8], length: row[9], time: row[10]}]->(s);

// -- -------------------------------------------------------------------------------------- --
// -- EXPRESSWAY: S7
// -- -------------------------------------------------------------------------------------- --
WITH [
	["Wien Mitte",3, "Landstraße","Wien","Rennweg",3, "Landstraße","Wien","S3",7.2,720],
	["Rennweg", 3,"Landstraße", "Wien","Flughafen Wien", 2460, "Bruck a.d. Leitha","Niederösterreich","S7", 14.1, 810]
] AS data
UNWIND data as row
MERGE (s:Station {name: row[0], plz: row[1], district: row[2], state: row[3]})
MERGE (s1:Station {name: row[4], plz: row[5], district: row[6], state: row[7]})
MERGE (s)-[c:EXPRESSWAY {code: row[8], length: row[9], time: row[10]}]->(s1)-[c1:EXPRESSWAY {code: row[8], length: row[9], time: row[10]}]->(s);


// -- -------------------------------------------------------------------------------------- --
// -- EXPRESSWAY: S80
// -- -------------------------------------------------------------------------------------- --
WITH [
	["Aspern Nord", 22,"Donaustadt", "Wien","Hirschstetten", 22, "Donaustadt","Wien","S80", 4.1, 560],
	["Hirschstetten", 22,"Donaustadt", "Wien","Stadlau", 22, "Donaustadt","Wien","S80", 7.8, 820],
	["Stadlau", 22,"Donaustadt", "Wien","Praterkai", 22, "Donaustadt","Wien","S80", 3.3, 350],
	["Praterkai", 22,"Donaustadt", "Wien","Simmering", 11, "Simmering","Wien","S80", 5.2, 560],
	["Simmering", 11,"Simmering", "Wien","Wien Hauptbahnhof", 4, "Wieden","Wien","S80", 6.7, 720],
	["Wien Hauptbahnhof",4, "Wieden","Wien","Matzleinsdorfer Platz",10,"Favoriten","Wien","S80",5.6,520],
	["Matzleinsdorfer Platz",10,"Favoriten","Wien","Wien Meidling",12, "Meidling","Wien","S80",6.2,550],
	["Wien Meidling", 12,"Meidling", "Wien","Hütteldorf", 14, "Penzing","Wien","S80", 4.5, 450]
] AS data
UNWIND data as row
MERGE (s:Station {name: row[0], plz: row[1], district: row[2], state: row[3]})
MERGE (s1:Station {name: row[4], plz: row[5], district: row[6], state: row[7]})
MERGE (s)-[c:EXPRESSWAY {code: row[8], length: row[9], time: row[10]}]->(s1)-[c1:EXPRESSWAY {code: row[8], length: row[9], time: row[10]}]->(s);


// -- -------------------------------------------------------------------------------------- --
// -- REGIONALEXPRESS: REX 4
// -- -------------------------------------------------------------------------------------- --
WITH [
	["Krems a.d. Donau", 3500,"Krems", "Niederösterreich","Hadersdorf", 3500, "Krems","Niederösterreich","REX4", 15.2, 620],
	["Hadersdorf", 3500,"Krems", "Niederösterreich","Fels", 3430, "Tulln","Niederösterreich","REX4", 14.2, 570],
	["Fels", 3430,"Tulln", "Niederösterreich","Kirchberg am Wagram", 3430, "Tulln","Niederösterreich","REX4", 7.2, 370],
	["Kirchberg am Wagram", 3430,"Tulln", "Niederösterreich","Absdorf", 3430, "Tulln","Niederösterreich","REX4", 8.1, 350],
	["Absdorf", 3430,"Tulln", "Niederösterreich","Tulln a.d. Donau", 3430, "Tulln","Niederösterreich","REX4", 14.2, 370],
	["Tulln a.d. Donau", 3430,"Tulln", "Niederösterreich","Heiligenstadt", 19, "Döbling","Wien","REX4", 32.2, 2100],
	["Heiligenstadt", 19, "Döbling","Wien","Spittelau", 9,"Alsergrund", "Wien","REX4",3.2, 120],
	["Spittelau", 9,"Alsergrund", "Wien","Franz-Josef Bahnhof", 9,"Alsergrund", "Wien","REX4", 1.8, 120]
] AS data
UNWIND data as row
MERGE (s:Station {name: row[0], plz: row[1], district: row[2], state: row[3]})
MERGE (s1:Station {name: row[4], plz: row[5], district: row[6], state: row[7]})
MERGE (s)-[c:REGIONAL_EXPRESS {code: row[8], length: row[9], time: row[10]}]->(s1)-[c1:REGIONAL_EXPRESS {code: row[8], length: row[9], time: row[10]}]->(s);


// -- -------------------------------------------------------------------------------------- --
// -- REGIONALEXPRESS: REX 5
// -- -------------------------------------------------------------------------------------- --
WITH [
	["Krems a.d. Donau", 3500,"Krems", "Niederösterreich","Furth", 3500, "Krems","Niederösterreich","REX5", 12.2, 710],
	["Furth", 3500,"Krems", "Niederösterreich","Herzogenburg", 3100, "St.Pölten","Niederösterreich","REX5", 14.2, 810],
	["Herzogenburg", 3100,"St.Pölten", "Niederösterreich","St.Pölten Hauptbahnhof", 3100, "St.Pölten","Niederösterreich","REX5", 15.1, 570]
] AS data
UNWIND data as row
MERGE (s:Station {name: row[0], plz: row[1], district: row[2], state: row[3]})
MERGE (s1:Station {name: row[4], plz: row[5], district: row[6], state: row[7]})
MERGE (s)-[c:REGIONAL_EXPRESS {code: row[8], length: row[9], time: row[10]}]->(s1)-[c1:REGIONAL_EXPRESS {code: row[8], length: row[9], time: row[10]}]->(s);
