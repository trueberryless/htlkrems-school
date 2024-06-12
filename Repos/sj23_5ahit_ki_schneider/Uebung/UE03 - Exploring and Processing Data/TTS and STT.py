#!/usr/bin/env python
# coding: utf-8

# # TTS

# In[3]:


get_ipython().system('pip install gtts')

from gtts import gTTS

tts = gTTS(text='I like NLP and especially Mr. Brunner', lang='en', slow=False)

tts.save("audio.mp3")


# In[4]:


tts = gTTS(text='I mag NLP und vor allem Herrn Brunner', lang='de', slow=False) 


# # STT

# In[9]:


get_ipython().system('pip install SpeechRecognition')
get_ipython().system('pip install PyAudio')
import speech_recognition as sr
r=sr.Recognizer()

with sr.Microphone() as source:
    print("Please say something")
    audio = r.listen(source, 10, 10)
    print("Time over, thanks")
    try:
        print("I think you said: "+r.recognize_google(audio))
    except:
        print("Cannot listen")

