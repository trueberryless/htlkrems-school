# 1. Fill the missing pieces
Fill the `____` parts of the code below.


```python
# Let's create an empty list
my_list = []

# Let's add some values
my_list.append('Python')
my_list.append('is ok')
my_list.append('sometimes')

# Let's remove 'sometimes'
my_list.remove('sometimes')

# Let's change the second item
my_list[1] = 'is neat'
```


```python
# Let's verify that it's correct
assert my_list == ['Python', 'is neat']
```

# 2. Create a new list without modifiying the original one



```python
original = ['I', 'am', 'learning', 'hacking', 'in']
```


```python
# Your implementation here
modified = original.copy();
modified[3] = 'lists';
modified.append('Python')
```


```python
assert original == ['I', 'am', 'learning', 'hacking', 'in']
assert modified == ['I', 'am', 'learning', 'lists', 'in', 'Python']
```

# 3. Create a merged sorted list


```python
list1 = [6, 12, 5]
list2 = [6.2, 0, 14, 1]
list3 = [0.9]
```


```python
# Your implementation here
my_list = sorted(list1 + list2 + list3)
my_list.reverse()
```


```python
print(my_list)
assert my_list == [14, 12, 6.2, 6, 5, 1, 0.9, 0]
```

    [14, 12, 6.2, 6, 5, 1, 0.9, 0]
    
