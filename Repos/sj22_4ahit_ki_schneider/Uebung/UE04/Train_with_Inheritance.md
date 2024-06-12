```python
class Passenger:    
    def __init__(self, name, valid_ticket):
        self._name = name
        self._valid_ticket = valid_ticket
        
class Train:
    def __init__(self):
        self._passengers = []
    
    def step_in(self, passenger):
        self._passengers.append(passenger)
            
    def step_out(self, passenger):
        self._passengers.remove(passenger)
    
    def print_passengers(self):
        for i in self._passengers:
            print (f"{i._name}, {i._valid_ticket}")

class RailJet(Train):
    def step_in(self, passenger):
        if passenger._valid_ticket is True:
            self._passengers.append(passenger)

class InterCity(Train):
    def __init__(self, ice_category):
        super().__init__()
        self._ICE_Category = ice_category
```


```python
p1 = Passenger('Yanik', False)
p2 = Passenger('Felix', True)
p3 = Passenger('Clemens', True)
```


```python
r1 = RailJet()
```


```python
r1.print_passengers()
```


```python
r1.step_in(p1)
r1.step_in(p2)
r1.step_in(p3)
```


```python
r1.print_passengers()
```

    Felix, True
    Clemens, True
    


```python
r1.step_out(p2)
```


```python
r1.print_passengers()
```

    Clemens, True
    


```python
i1 = InterCity("ICE187")
```


```python
i1.print_passengers()
```


```python
i1.step_out(p2) # not working
```


    ---------------------------------------------------------------------------

    ValueError                                Traceback (most recent call last)

    Input In [155], in <cell line: 1>()
    ----> 1 i1.step_out(p2)
    

    Input In [145], in Train.step_out(self, passenger)
         13 def step_out(self, passenger):
    ---> 14     self._passengers.remove(passenger)
    

    ValueError: list.remove(x): x not in list



```python
i1.step_in(p3)
```


```python
i1.print_passengers()
```

    Clemens, True
    
