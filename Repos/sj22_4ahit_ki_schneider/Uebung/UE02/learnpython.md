```python
one = 1
```


```python
type(one)
```




    int




```python
two = 2
```


```python
somestring = "a text"
```


```python
type(somestring)
```




    str




```python
boolean = True
```


```python
type(boolean)
```




    bool




```python
if True:
    print("juhu")
```

    juhu
    


```python
if False:
    print("Never see you again!")
```


```python
num = 1

while num <= 100:
    num*=2
    print("a")
```

    a
    a
    a
    a
    a
    a
    a
    


```python
for i in range(1,10):
    print(i)
```

    1
    2
    3
    4
    5
    6
    7
    8
    9
    


```python
for i in 1,2,3,4:
    print(i)
```

    1
    2
    3
    4
    


```python
[*range(1,11)]
```




    [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]




```python
list(range(1,11))
```




    [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]




```python
my_integers = [1, 2, 3, 4, 5]
```


```python
print(my_integers)
```

    [1, 2, 3, 4, 5]
    


```python
type(my_integers)
```




    list




```python
my_integers.append(6)
```


```python
dictionary = { "some_key": "some_value" }

for key in dictionary:
    print("%s --> %s" %(key, dictionary[key]))
```

    some_key --> some_value
    


```python
print(dictionary['some_key'])
```

    some_value
    


```python
print(dictionary)
```

    {'some_key': 'some_value'}
    
