#!/usr/bin/env python
# coding: utf-8

# In[19]:


import re


# In[20]:


import urllib.request as urllib2
from bs4 import BeautifulSoup
# Website laden
response = urllib2.urlopen('https://www.htlkrems.ac.at')
html_doc = response.read()
# Das BeautifulSoup Object soup repräsentiert das „geparste“ HTML-Dokument
soup = BeautifulSoup(html_doc, 'html.parser')
# Das „geparste“ HTML-Dokument formatieren, sodass jeder Tag bzw. Textblock
# in einer separaten Zeile ausgegeben wird
strhtm = soup.prettify()

email = re.findall("\S+@\S+\.\S{2,3}", strhtm)
print(email)


# In[21]:


import csv

with open('email.csv', 'w') as file:
    writer = csv.writer(file)
    writer.writerow(email)


# In[22]:


# Website laden
response = urllib2.urlopen('https://www.gamespot.com/games/reviews/?review_filter_type%5Bplatform%5D=&review_filter_type%5Bgenre%5D=4&review_filter_type%5BtimeFrame%5D=P12M&review_filter_type%5BstartDate%5D=&review_filter_type%5BendDate%5D=&review_filter_type%5BminRating%5D=&review_filter_type%5Btheme%5D=&review_filter_type%5Bregion%5D=&review_filter_type%5Bletter%5D=&sort=gs_score_desc')
html_doc = response.read()
# Das BeautifulSoup Object soup repräsentiert das „geparste“ HTML-Dokument
soup = BeautifulSoup(html_doc, 'html.parser')
# Das „geparste“ HTML-Dokument formatieren, sodass jeder Tag bzw. Textblock
# in einer separaten Zeile ausgegeben wird
strhtm = soup.prettify()


# In[25]:


# Loop through the cards and create a DataFrame for each card's data
for card in soup.findAll('div', attrs={'class': 'card-item__content'}, limit=3):
    print(card.find('h4').text)
    print(card.find('span').text)
    print(card.find('div').findAll('div')[2].find('span').text)
    print('-' * 50)


# In[24]:


import pandas as pd

# Initialize an empty DataFrame with the desired columns
df = pd.DataFrame(columns=['Title', 'Platform', 'NumOfThumbsUp'])

# Loop through the cards and create a DataFrame for each card's data
for card in soup.findAll('div', attrs={'class': 'card-item__content'}):
    title = card.find('h4').text
    platform = card.find('span').text
    num_of_thumbs_up = card.find('div').findAll('div')[2].find('span').text
    
    # Create a DataFrame for the current card's data
    card_df = pd.DataFrame({'Title': [title], 'Platform': [platform], 'NumOfThumbsUp': [num_of_thumbs_up]})
    
    # Concatenate the current card's DataFrame with the main DataFrame
    df = pd.concat([df, card_df], ignore_index=True)

# Print the resulting DataFrame
print(df)

