#!/usr/bin/env python
# coding: utf-8

# In[1]:


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


# In[13]:


ba2 = BankAccount()


# In[15]:


print(ba2.get_balance())


# In[2]:


ba = BankAccount(1234)


# In[3]:


print(ba.get_balance())


# > deposit (working)

# In[4]:


ba.deposit(5678)


# In[5]:


print(ba.get_balance())


# > withdraw (working)

# In[6]:


ba.withdraw(6543)


# In[7]:


print(ba.get_balance())


# > withdraw under -1000 doesn't work:

# In[8]:


ba.withdraw(9876)


# In[9]:


print(ba.get_balance())


# > freeze account disables deposit and withdraw

# In[10]:


ba.freeze_account()


# In[11]:


ba.deposit(13579)


# In[12]:


print(ba.get_balance())

