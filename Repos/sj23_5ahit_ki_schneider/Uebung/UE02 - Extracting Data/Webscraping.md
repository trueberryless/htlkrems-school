```python
import re
```


```python
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
```

    ['office@htlkrems.at']
    


```python
import csv

with open('email.csv', 'w') as file:
    writer = csv.writer(file)
    writer.writerow(email)
```


```python
# Website laden
response = urllib2.urlopen('https://www.gamespot.com/games/reviews/?review_filter_type%5Bplatform%5D=&review_filter_type%5Bgenre%5D=4&review_filter_type%5BtimeFrame%5D=P12M&review_filter_type%5BstartDate%5D=&review_filter_type%5BendDate%5D=&review_filter_type%5BminRating%5D=&review_filter_type%5Btheme%5D=&review_filter_type%5Bregion%5D=&review_filter_type%5Bletter%5D=&sort=gs_score_desc')
html_doc = response.read()
# Das BeautifulSoup Object soup repräsentiert das „geparste“ HTML-Dokument
soup = BeautifulSoup(html_doc, 'html.parser')
# Das „geparste“ HTML-Dokument formatieren, sodass jeder Tag bzw. Textblock
# in einer separaten Zeile ausgegeben wird
strhtm = soup.prettify()
```


```python
# Loop through the cards and create a DataFrame for each card's data
for card in soup.findAll('div', attrs={'class': 'card-item__content'}, limit=3):
    print(card.find('h4').text)
    print(card.find('span').text)
    print(card.find('div').findAll('div')[2].find('span').text)
    print('-' * 50)
```

    The Witcher 3: Wild Hunt Next-Gen Update Review - Wind's Howlin'
    PS5
    1912
    --------------------------------------------------
    Resident Evil 4 Remake Review - Stranga, Stranga, Now That's A Remake
    PS5
    33
    --------------------------------------------------
    The Legend Of Zelda: Tears Of The Kingdom Review
    NS
    27
    --------------------------------------------------
    


```python
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
```

                                                    Title Platform NumOfThumbsUp
    0   The Witcher 3: Wild Hunt Next-Gen Update Revie...      PS5          1912
    1   Resident Evil 4 Remake Review - Stranga, Stran...      PS5            33
    2    The Legend Of Zelda: Tears Of The Kingdom Review       NS            27
    3   Cyberpunk 2077: Phantom Liberty Review - The S...       PC            18
    4             Bayonetta 3 Review - Real Hot Girls Hit       NS            28
    5   God Of War Ragnarok Review - Blood, Sweat, And...      PS5            28
    6   World Of Warcraft: Dragonflight Review - Who S...       PC             7
    7          Dead Space Remake Review - Hits The Marker       PC            25
    8                 Hi-Fi Rush Review - Good Vibes Only     XBSX            14
    9   Bayonetta Origins: Cereza And The Lost Demon -...       NS             5
    10          Street Fighter 6 Review - Battle Hardened      PS5            13
    11         Final Fantasy 16 Review - On Its Own Terms      PS5            25
    12           Blasphemous 2 Review - Unholy Pilgrimage       PC             6
    13  The Texas Chain Saw Massacre Review - Thrill O...     XBSX            14
    14                     Cocoon Review - A Bug's Strife       PC             3
    15                              Nier: Automata Review   NS, NS           279
    16           Overwatch 2 Review - Same As It Ever Was       PC            10
    17         Lego Bricktales Review: Build Brick Better       PC            10
    18                    Signalis Review - Silent Thrill     XONE             5
    19  Call Of Duty: Modern Warfare 2 Campaign Review...      PS5            14
    20  Call Of Duty: Warzone 2 Review - Al Mazrah Shines      PS5             7
    
