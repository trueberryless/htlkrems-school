# 1. Creating formulas
Write the following mathematical formula in Python:

\begin{align}
 result = 6a^3 - \frac{8b^2 }{4c} + 11
\end{align}



```python
a = 2
b = 3
c = 2
```


```python
# Your formula here:
result = (6*a**3)-((8*b**2)/(4*c))+11
print(result)
```

    50.0
    


```python

assert result == 50
```

# 2. Floating point pitfalls
Show that `0.1 + 0.2 == 0.3`


```python
# Your solution here
print(round(0.1 + 0.2, 2) == 0.3)
# This won't work:
assert round(0.1 + 0.2, 2) == 0.3
```

    True
    
