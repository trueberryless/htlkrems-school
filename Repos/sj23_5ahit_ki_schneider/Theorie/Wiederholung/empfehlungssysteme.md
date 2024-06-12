## Hyperparameter Optimierung

### CVGS

Cross Validation: Daten in x (meist 5) Pakete aufgeteilt, sodass immer mit 4 Trainiert und 1 Validiert werden kann. Dabei werden die Pakete verschoben, um ein Overfitting (zu Stark an die Trainingsdaten angepasst) zu vermeiden.

Grid Search: Da gibt man eine Range für die Parameter an (welche für die Accuracy des Classifiers relevant sind (zB Anzahl der Bäume)) und probiert das Trainieren mit allen Kombinationen (wenn Random, nur mit manchen zufälligen Kombinationen).

## Model Altering

Qualität des Modells für die Datengrundlage noch gültig? Vor allem bei dynamischen Bereichen gibt es ständige Änderungen, weshalb die Daten schnell altern können. ZB Fraud Detection.

Mittels Retraining müssen die Modelle dann neu trainiert werden.

## Datengrundlage

### Überanpassung (Overfitting)

ZB Bildergeneration Training: Hasen immer auf Gras sitzen, dann glaubt KI, Gras gehört zum Hasen
