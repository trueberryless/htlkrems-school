### Ausführung des Prototypen

Kopieren Sie bitte alle Daten auf eine Festplatte, um die Applikation zum Laufen zu bringen.

Die Ausführung unserer Applikation kann mithilfe der Dateien auf dem USB-Stick und der _Docker Engine_ durchgeführt werden. Hierfür muss man einfach in das Verzeichnis **prototype/** wechseln und diesen Befehl durchführen (Powershell unter Windows):

```bash
docker compose up -d
```

Damit anschließend auch Testdaten in der Datenbank verfügbar sind, muss ein Powershell-Script ausgeführt werden. Die Anweisung dafür ist im Quellcode unterhalb zu finden.

```bash
cd .\prototype\test_data\
powershell.exe .\run_insert.ps1
```

Die Dauer der Ausführung des Einfügeprozesses der Testdaten des Stromnetzwerkes beträgt in etwa fünf Minuten.

Möglicherweise müssen Sie die Ausführung von Scripten aktivieren:

```bash
Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser
```
