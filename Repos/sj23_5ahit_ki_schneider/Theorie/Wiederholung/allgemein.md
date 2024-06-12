# Zusammenfassung behandelter Inhalte

**Disclaimer**: Kein Anspruch auf Vollständigkeit! Prinzipiell ist der Stoff der 4. und 5. Klasse prüfungsrelevant.

## Machine Learning

-   Was ist das?
-   Welche Arten des Lernen gibt es? Supervised, Unsupervised, ...
-   Erfolgsfaktoren: Warum konnte Machine Learning in den letzten Jahren so eine Bedeutung erlangen? (12-15y)
    -   Demokratisierung der KI
    -   Hardware (NVIDIA) ermöglicht es
    -   Investoren erkennen, wie wertvoll das ist (dritte KI Hype) -> Pushed
    -   Daten sammeln wurde "abgeschlossen" (vorher schon begonnen, jetzt Daten vorhanden)
-   Unterscheidung zum klassischen Programmieren: Daten sind essenziell zum Trainieren; Programmieren eig nur Datenaufbereitung (Data Cleaning)
    Trainiertes Modell besteht aus Layern, welche mittels Code zusammengebaut werden und anschließend gefittet werden.
-   Welche Problemstellungen lassen sich damit lösen?
-   Prinzipielle Vorgehensweise - Ablauf bzw. Prozess?
    -   Daten besorgen
    -   Daten aufbereiten -> siehe Ablaufdiagramm
-   Arten von Aufgaben
    -   Klassifizierung (shallow learning / flache Lernen)
        -   RFC (inkl. Details: Ensemble, Bagging, Mehrheitsentscheid, ...)
            -   sklearn -> RandomForestClassifier: beim Instantiieren die Hyperparameter und andere Parameter festlegen. Diese bestimmen, wie das Modell trainiert wird (Anzahl der Bäume)
            -   Cross Validation mit Random
            -   Grid Search
        -   Logisic Regression
        -   SVM (Support Vector Machine)
        -   Neuronalen Netzwerken
        -   Convolutional Neural Netzwork (Machinelles Sehen): Bildklassifizierung
    -   Regression (deep learning)
        -   einfache und multiple lineare Regression
        -   keine Klassifizierung: Vorhersage eines Liegenschaftspreises (Boston House Prices) (ein Skalar wird vorhergesagt; zB Gewicht mittels Körpergröße vorhersagen)
            -   MSE / MAE minimieren
            -   Normalisieren -> Boxplot gemacht
-   Verschiedene Begrifflichkeiten
    -   Overfitting
    -   Model Deterioration
    -   Metriken (Accuracy, Precision, Recall, F1-Score, ...)
    -   Confusion Matrix

## Big Data

-   Was ist das? Was ist der Zweck? Ab wann Big Data?
    -   Bedeutung der Datenqualität?
        -   Wenn man mit Müll trainiert, ist auch das trainierte Modell Müll.
    -   NLP (Natural Language Processing)
        -   großteil der Daten unstrukturiert
-   Einordnung der Begriffe
    -   Machine Learning
    -   Big Data
    -   AI (Deep Learning)

## Deskriptive Statistik

-   Mittelwert (Mean), Median, Modal
-   links- und rechtsschiefe Daten (Ausreißer)
-   Zusammensetung Boxplot (Q1, Q2, Q3, unterer / oberer Whisker); bissl erklären können

## Merkmalstypen

-   kategoriale / numerische Daten / Merkmale unterscheiden
    -   zB PLZ numerisch?

## Visualisierung mit Matplotlib und Seaborn

-   Histogram
-   Scatterplot (Punt-Wolken-Diagramm)
-   Boxplot

---

-   kein Code schrieben
-   nur Lesen und Interpretieren

## Empfehlungssysteme

-   Was ist das? Zweck und Arten?
    -   kollaberativ
-   Cosine Similarity (um Ähnlichkeiten zw. Usern bestimmen zu können): Die beiden Tabellen aus Boxtree erklären können
-   Gewichteter Mittelwert erläutern können

## Neuronale Netze

-   Aufbau und Funktionsweise eines Perzeptrons
-   moderne neuronale Netze anschauen und skizzieren (siehe MNIST) und deren Aktivierungsfunktionen (ReLU, Sigmoid, Softmax)
    -   Binär- und Mehrklassenproblem (je nach Problem ist dann die Aktivierungsfunktion des Output-Layers richtig zu wählen)
-   stehen für das sogenannte Deep Learning -> n vielen Ebenen / Schichten bestehen
-   Feed Forward Propagation (siehe Hotdog-Bsp.)
-   Traininsprozess im Detail (Backward Propagation)
-   Epoche, Batch Size oder Iteration
-   Model Summary
-   Einfache Codesnippets implementieren können
    -   zB Dense-Layer einem Sequential-Stack hinzufügen
    -   Compile und Fit notwendig, Was macht das? Beim Kompilieren Epochen festlegen und dann fitten

### CNN

-   Convolutional Neural Network
-   damit können Machinen sehen
-   Grundlegende Aufbau: Faltungsteil (verschiedene Layer) und Klassifizierungsteil
-   verschiedene Layer-Typen:
    -   Flatten (Faltung, Pooling und Stride theoretisch erklären können)
    -   Dropout
    -   Stride
    -   Pooling
-   Model Summary

## Data Science

-   Numpy und Pandas
-   mit Daten umgehen können (Laden, Lesen, Filtern, Sortieren,...)
-   Skalar, Vektor, Matrix, Tensor, ... (siehe Bilddaten Beispiel; max 4D-Tensor)
    -   Shape Bedeutung interpretieren können
-   CSV einlesen, Slicing und Selektion von Spalten / Zeilen
-   info, describe, mean, max, min, std, var, count, unique, value_counts, corr, sort_values, isna...
    -   alle wichtigen Methoden, die es für die Explorative Daten Analyse und Datenaufbereitung gebraucht hat

## NLP (Natural Language Processing)

-   Was ist das? Was ist der Zweck?
-   Warum ist NLP so wichtig geworden?
-   Extrakting Data
    -   RegEx
    -   Welche Artefakte kann man verarbeiten (PDF, Web Scrapping)?
    -   Pipeline (spaCy) verstehen (Stufen)
-   Part of Speech Tagging
-   Named Entity Recognition
-   Converting Text to Features
    -   Word Embeddings
    -   Bag of Words
    -   TF-IDF
    -   One-Hot-Encoding
-   Sentiment Analysis
    -   Vader
    -   Transformers
        -   siehe UE06
        -   inkl. Theorie (AWS)
        -   Use Cases und Project Lifecycle

## Alles zum Thema KI und Gesellschaft
