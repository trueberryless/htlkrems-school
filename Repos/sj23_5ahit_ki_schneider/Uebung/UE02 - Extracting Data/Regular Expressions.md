```python
import re
```


```python
p = re.compile("5")
print(p.findall("Für 5 Semmeln habe ich 3.90€ bezahlt.")) 
```

    ['5']
    


```python
p = re.compile("[0-9]")
print(p.findall("Für 5 Semmeln habe ich 3.90€ bezahlt."))
```

    ['5', '3', '9', '0']
    


```python
p = re.compile(" [0-9] ")
print(p.findall("Für 5 Semmeln habe ich 3.90€ bezahlt."))
```

    [' 5 ']
    


```python
p = re.compile("[0-9]\.[0-9][0-9]") 
print(p.findall("Für 5 Semmeln habe ich 3.90€ bezahlt."))
```

    ['3.90']
    


```python
p = re.compile("[0-9]\.[0-9][0-9][€$]") 
print(p.findall("Für 5 Semmeln habe ich 3.90€ bezahlt."))
print(p.findall("Für 5 Semmeln habe ich 3.90$ bezahlt."))
```

    ['3.90€']
    ['3.90$']
    


```python
p = re.compile(" [0-9] ")
print(p.findall("Für 5 Semmeln habe ich 3.90€ bezahlt."))
print(p.findall("Für 15 Semmeln habe ich 19.50$ bezahlt."))
print(p.findall("Für 150 Semmeln habe ich 190.50$ bezahlt.")) 
```

    [' 5 ']
    []
    []
    


```python
# Also this pattern only matches if there are exactly three numbers.
p = re.compile(" [0-9][0-9][0-9] ")
print(p.findall("Für 5 Semmeln habe ich 3.90€ bezahlt."))
print(p.findall("Für 15 Semmeln habe ich 19.50$ bezahlt."))
print(p.findall("Für 150 Semmeln habe ich 190.50$ bezahlt.")) 
```

    []
    []
    [' 150 ']
    


```python
p = re.compile(" [0-9]+ ")
print(p.findall("Für 5 Semmeln habe ich 3.90€ bezahlt."))
print(p.findall("Für 15 Semmeln habe ich 19.50$ bezahlt."))
print(p.findall("Für 150 Semmeln habe ich 190.50$ bezahlt."))
```

    [' 5 ']
    [' 15 ']
    [' 150 ']
    


```python
p = re.compile(" [0-9]+\.[0-9][0-9][€$] ")
print(p.findall("Für 5 Semmeln habe ich 3.90€ bezahlt."))
print(p.findall("Für 15 Semmeln habe ich 19.50$ bezahlt."))
print(p.findall("Für 150 Semmeln habe ich 190.50$ bezahlt.")) 
```

    [' 3.90€ ']
    [' 19.50$ ']
    [' 190.50$ ']
    


```python
p = re.compile(" [0-9]+\.[0-9]{2}[€$] ")
print(p.findall("Für 5 Semmeln habe ich 3.90€ bezahlt."))
print(p.findall("Für 15 Semmeln habe ich 19.50$ bezahlt."))
print(p.findall("Für 150 Semmeln habe ich 190.50$ bezahlt.")) 
```

    [' 3.90€ ']
    [' 19.50$ ']
    [' 190.50$ ']
    


```python
p = re.compile(" [0-9]+[\.,][0-9]{2}[€$]? ")
print(p.findall("Für 5 Semmeln habe ich 3.90€ bezahlt."))
print(p.findall("Für 15 Semmeln habe ich 19.50$ bezahlt."))
print(p.findall("Für 150 Semmeln habe ich 190,50 bezahlt."))
```

    [' 3.90€ ']
    [' 19.50$ ']
    [' 190,50 ']
    


```python
p = re.compile("Telefonnummer")
print(p.search("Meine Telefonnummer ist 0664 555 0 123. Ruf schnell an!")) 
```

    <re.Match object; span=(6, 19), match='Telefonnummer'>
    


```python
match = p.search("Meine Telefonnummer ist 0664 555 0 123. Ruf schnell an!")
print(match.span())
print(match.start())
print(match.end()) 
```

    (6, 19)
    6
    19
    


```python
match = p.match("Meine Telefonnummer ist 0664 555 0 123. Ruf schnell an!")
print(match) 
```

    None
    


```python
match = p.finditer("Meine Telefonnummer ist 0664 555 0 123. Ruf schnell an!")
print(match)
```

    <callable_iterator object at 0x0000014CE2867DF0>
    


```python
print(re.search("Frau|Herr", "Sehr geehrte Frau Musterfrau! Ich darf Sie darauf hinweisen, dass..."))
print(re.search("Frau|Herr", "Sehr geehrter Herr Mustermann! Ich darf Sie darauf hinweisen, dass...")) 
```

    <re.Match object; span=(13, 17), match='Frau'>
    <re.Match object; span=(14, 18), match='Herr'>
    


```python
re.findall(".und","Der Hund hat keinen Mund ")
```




    ['Hund', 'Mund']




```python
someText = ["a", "abc", "bac"]
for text in someText:
     print(re.findall("^a", text)) 
```

    ['a']
    ['a']
    []
    


```python
someNewText = ["a", "formula", "bac"]
for text in someText:
     print(re.findall("a$", text)) 
```

    ['a']
    []
    []
    


```python
re.findall("[^ ]","Das ist ein Text mit Leerzeichen!") 
```




    ['D',
     'a',
     's',
     'i',
     's',
     't',
     'e',
     'i',
     'n',
     'T',
     'e',
     'x',
     't',
     'm',
     'i',
     't',
     'L',
     'e',
     'e',
     'r',
     'z',
     'e',
     'i',
     'c',
     'h',
     'e',
     'n',
     '!']




```python

```
