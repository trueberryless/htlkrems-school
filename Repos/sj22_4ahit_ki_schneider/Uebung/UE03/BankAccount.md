```python
class BankAccount:
    # pass ist ein Platzhalter
    
    #def __init__(self):
    #    self.__balance = 0
    #    self.account_is_freezed = False
    
    
    # Man kann Standardwerte definieren, falls der Parameter nicht übergeben wird
    def __init__(self, balance=0):
        self.__balance = balance
        self.account_is_freezed = False
        
    def freeze_account(self):
        if self.account_is_freezed:
            self.account_is_freezed = False
        else:
            self.account_is_freezed = True
    
    def withdraw(self, amount):
        if not self.account_is_freezed:
            if self.__balance - amount >= -1000:
                self.__balance = self.__balance - amount
        else:
            print(f"Your account is frozen forever!")
    
    def deposit(self, amount):
        if not self.account_is_freezed:
            self.__balance = self.__balance + amount
        else:
            print(f"Your account is frozen forever!")
            
    def get_balance(self):
        return f"Your current balance is: {self.__balance:>{10}}"
```


```python
ba2 = BankAccount()
```


```python
print(ba2.get_balance())
```

    Your current balance is:          0
    


```python
ba = BankAccount(1234)
```


```python
print(ba.get_balance())
```

    Your current balance is:       1234
    

> deposit (working)


```python
ba.deposit(5678)
```


```python
print(ba.get_balance())
```

    Your current balance is:       6912
    

> withdraw (working)


```python
ba.withdraw(6543)
```


```python
print(ba.get_balance())
```

    Your current balance is:        369
    

> withdraw under -1000 doesn't work:


```python
ba.withdraw(9876)
```


```python
print(ba.get_balance())
```

    Your current balance is:        369
    

> freeze account disables deposit and withdraw


```python
ba.freeze_account()
```


```python
ba.deposit(13579)
```

    Your account is frozen forever!
    


```python
print(ba.get_balance())
```

    Your current balance is:        369
    
