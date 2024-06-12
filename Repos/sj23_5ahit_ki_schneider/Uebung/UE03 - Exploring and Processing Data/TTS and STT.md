# TTS


```python
!pip install gtts

from gtts import gTTS

tts = gTTS(text='I like NLP and especially Mr. Brunner', lang='en', slow=False)

tts.save("audio.mp3")
```

    Requirement already satisfied: gtts in c:\users\trueb\anaconda3\lib\site-packages (2.4.0)
    Requirement already satisfied: requests<3,>=2.27 in c:\users\trueb\anaconda3\lib\site-packages (from gtts) (2.31.0)
    Requirement already satisfied: click<8.2,>=7.1 in c:\users\trueb\anaconda3\lib\site-packages (from gtts) (8.0.4)
    Requirement already satisfied: colorama in c:\users\trueb\anaconda3\lib\site-packages (from click<8.2,>=7.1->gtts) (0.4.6)
    Requirement already satisfied: charset-normalizer<4,>=2 in c:\users\trueb\anaconda3\lib\site-packages (from requests<3,>=2.27->gtts) (2.0.4)
    Requirement already satisfied: idna<4,>=2.5 in c:\users\trueb\anaconda3\lib\site-packages (from requests<3,>=2.27->gtts) (3.4)
    Requirement already satisfied: urllib3<3,>=1.21.1 in c:\users\trueb\anaconda3\lib\site-packages (from requests<3,>=2.27->gtts) (1.26.16)
    Requirement already satisfied: certifi>=2017.4.17 in c:\users\trueb\anaconda3\lib\site-packages (from requests<3,>=2.27->gtts) (2023.7.22)
    


```python
tts = gTTS(text='I mag NLP und vor allem Herrn Brunner', lang='de', slow=False) 
```

# STT


```python
!pip install SpeechRecognition
!pip install PyAudio
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
```

    Requirement already satisfied: SpeechRecognition in c:\users\trueb\anaconda3\lib\site-packages (3.10.0)
    Requirement already satisfied: requests>=2.26.0 in c:\users\trueb\anaconda3\lib\site-packages (from SpeechRecognition) (2.31.0)
    Requirement already satisfied: charset-normalizer<4,>=2 in c:\users\trueb\anaconda3\lib\site-packages (from requests>=2.26.0->SpeechRecognition) (2.0.4)
    Requirement already satisfied: idna<4,>=2.5 in c:\users\trueb\anaconda3\lib\site-packages (from requests>=2.26.0->SpeechRecognition) (3.4)
    Requirement already satisfied: urllib3<3,>=1.21.1 in c:\users\trueb\anaconda3\lib\site-packages (from requests>=2.26.0->SpeechRecognition) (1.26.16)
    Requirement already satisfied: certifi>=2017.4.17 in c:\users\trueb\anaconda3\lib\site-packages (from requests>=2.26.0->SpeechRecognition) (2023.7.22)
    Requirement already satisfied: PyAudio in c:\users\trueb\anaconda3\lib\site-packages (0.2.14)
    Please say something
    Time over, thanks
    Cannot listen
    
