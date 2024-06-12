## Wiederholung Properties und Inheritance

### Bsp. 04.1
Vervollständigen Sie nachfolgende Klasse `Robot` mit dem Ziel der *Blacklist*-Überprüfung. Generell gilt: Wird beim Instanziieren keine Name angegeben oder ist dieser in der Blacklist `_fobidden_names` angeführt, gilt es den *Default*-Namen *Marvin* zuzuweisen. In allen anderen Fällen ist der Name gemäß Argument zu setzen.    


```python
class Robot:
    
    _forbidden_names = ["Charly", "Alan"]
    _standard_name = "Martin"
    
    def __init__(self, name=_standard_name):
        self.set_name(name)
        
    
    def get_name(self):
        return self.name
    
    
    def set_name(self, name):
        if(name in self._forbidden_names):
            self.name = self._standard_name
        else:
            self.name = name 
```

**Testszenarien**: Zeigen Sie die Funktionsweise anhand nachfolgender Tests!


```python
r = Robot()
r.get_name()
# Output: 'Marvin'
```




    'Martin'




```python
r2=Robot("Alan")
r2.get_name()
# Output: 'Marvin'
```




    'Martin'




```python
r3=Robot("Markus")
r3.get_name()
# Output: 'Markus'
```




    'Markus'



### Bsp. 04.2
Durch den Einsatz der *Decorators* `@property` und `@...setter` kann man, wie es in Python üblich ist, via Attribut zugreifen - also "pythonsich". Adaptieren Sie den Code vom ersten Bsp.:


```python
class Robot:
    
    _forbidden_names = ["Charly", "Alan"]
    _standard_name = "Marvin"
    
    def __init__(self, name=_standard_name):
        self.name = name
        
    @property
    def name(self):
        return self._name
    
    @name.setter
    def name(self, name=_standard_name):
        if(name in self._forbidden_names):
            self._name = self._standard_name
        else:
            self._name = name 
```

**Testszenarien**: Zeigen Sie die Funktionsweise anhand nachfolgender Tests!


```python
r = Robot("Charly")
print(r.name)
r.name="Alan"
print(r.name)
r.name="Flo"
print(r.name)
```

    Marvin
    Marvin
    Flo
    

### Bsp. 04.3 - Inheritance
Gegeben ist die Klasse `Robot` mit folgender Implementierung:


```python
class Robot():
    
    _standard_name = "Marvin"
    
    def __init__(self, name=_standard_name):
        self.name=name
    
    
    def say_hello(self):
        return f"Hello, I'm {self.name}"
```

`say_hello` liefert folgenden Output:


```python
r3 = Robot()
r3.say_hello()
```




    "Hello, I'm Marvin"



Die Klasse `MedicalRobot` ist von `Robot` abgeleitet und ergänzt diese um die Methode `heal`, die einen beliebigen Namen als Argument übernimmt und ausgibt.


```python
class MedicalRobot(Robot):
    
    def heal(self, name):
        return f"{name} is healed now, or maybe not!"
```


```python
mr2 = MedicalRobot()
mr2.heal("Kelvin")
```




    'Kelvin is healed now, or maybe not!'



Überschreiben Sie in der Klasse `MedicalRobot` die Methode `say_hello` mit dem Ziel, dass nachfolgende Tests das definierte Ergebnis liefern.


```python
class MedicalRobot(Robot):
    
    def heal(self, x):
        return f"{x} is healed now, or maybe not!"
    
    def say_hello(self):
        return f"Hello, I'm {self.name}, your personal nurse!"
```

**Tests**:


```python
mr = MedicalRobot("Kelvin")
print(mr.say_hello())
# Output: Hello, I'm Kelvin, your personal nurse!
```

    Hello, I'm Kelvin, your personal nurse!
    
