#!/usr/bin/env python
# coding: utf-8

# In[8]:


import spacy
nlp = spacy.load('en_core_web_sm')
doc = nlp('Apple is looking at buying U.K. startup for $1 billion')
for ent in doc.ents:
    print(ent.text, ent.start_char, ent.end_char, ent.label_, spacy.explain(ent.label_))


# In[9]:


from spacy import displacy
displacy.render(doc, style="ent") 


# # NER-Tags
# ![image-2.png](attachment:image-2.png)

# In[10]:


text = "Dear Joe! I have organized a meeting with Elon Musk from Siemens for tomorrow. Meeting place is Vienna."
doc = nlp(text)
for ent in doc.ents:
    if ent.label_ == "PERSON":
        print(ent.text)


# In[11]:


for token in doc:
    print(f'{token.text:10} {token.ent_iob_} {token.ent_type_}')


# In[13]:


import PyPDF2 as pypdf
nlp = spacy.load('de_core_news_sm')
with open('BerichtHypo-UntersuchungskommissionKurzfassung.pdf', 'rb') as pdf:
    reader = pypdf.PdfReader(pdf)
    text = ""
    for page in reader.pages:
        text += page.extract_text()
    
    docs = nlp(text)
    #redacted_text = ''.join([token.text.replace(token.text, '[REDACTED]') if token.ent_iob_ in ['B', 'I'] and token.ent_type_ in ['PERSON'] else token.text for token in docs])
    redacted_text = ''
    for token in docs:
        if token.ent_type_ in ['PER'] and token.ent_iob_ in ['B']:
            redacted_text += '[REDACTED]'
        elif token.ent_type_ not in ['PER']:
            redacted_text += token.text
    print(redacted_text)

