```python
import spacy
nlp = spacy.load('en_core_web_sm')
doc = nlp('Apple is looking at buying U.K. startup for $1 billion')
for ent in doc.ents:
    print(ent.text, ent.start_char, ent.end_char, ent.label_, spacy.explain(ent.label_))
```

    Apple 0 5 ORG Companies, agencies, institutions, etc.
    U.K. 27 31 GPE Countries, cities, states
    $1 billion 44 54 MONEY Monetary values, including unit
    


```python
from spacy import displacy
displacy.render(doc, style="ent") 
```


<span class="tex2jax_ignore"><div class="entities" style="line-height: 2.5; direction: ltr">
<mark class="entity" style="background: #7aecec; padding: 0.45em 0.6em; margin: 0 0.25em; line-height: 1; border-radius: 0.35em;">
    Apple
    <span style="font-size: 0.8em; font-weight: bold; line-height: 1; border-radius: 0.35em; vertical-align: middle; margin-left: 0.5rem">ORG</span>
</mark>
 is looking at buying 
<mark class="entity" style="background: #feca74; padding: 0.45em 0.6em; margin: 0 0.25em; line-height: 1; border-radius: 0.35em;">
    U.K.
    <span style="font-size: 0.8em; font-weight: bold; line-height: 1; border-radius: 0.35em; vertical-align: middle; margin-left: 0.5rem">GPE</span>
</mark>
 startup for 
<mark class="entity" style="background: #e4e7d2; padding: 0.45em 0.6em; margin: 0 0.25em; line-height: 1; border-radius: 0.35em;">
    $1 billion
    <span style="font-size: 0.8em; font-weight: bold; line-height: 1; border-radius: 0.35em; vertical-align: middle; margin-left: 0.5rem">MONEY</span>
</mark>
</div></span>


# NER-Tags
![image-2.png](attachment:image-2.png)


```python
text = "Dear Joe! I have organized a meeting with Elon Musk from Siemens for tomorrow. Meeting place is Vienna."
doc = nlp(text)
for ent in doc.ents:
    if ent.label_ == "PERSON":
        print(ent.text)
```

    Joe
    Elon Musk
    


```python
for token in doc:
    print(f'{token.text:10} {token.ent_iob_} {token.ent_type_}')
```

    Dear       O 
    Joe        B PERSON
    !          O 
    I          O 
    have       O 
    organized  O 
    a          O 
    meeting    O 
    with       O 
    Elon       B PERSON
    Musk       I PERSON
    from       O 
    Siemens    B ORG
    for        O 
    tomorrow   B DATE
    .          O 
    Meeting    O 
    place      O 
    is         O 
    Vienna     B GPE
    .          O 
    


```python
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
```

     
      
     
      
    Bericht 
     
    der unabhängigen Untersuchungskommission 
    zur transparenten Aufklärung der Vorkommnisse rund um die Hypo 
    Group Alpe‐Adria 
     
    Kurzfassung 
     
      
     
       
    Wien, 2. Dezember 2014 
       
      
     
     
     
      
     
     
     
     
     
      
     
     
     
     
     
      
     
     
     Diese Kurzfassung, eine englische Übersetzung und die Langfassung des Berichts sind unter 
    [REDACTED] abrufbar. 
       
     Inhaltsverzeichnis 
    A. [REDACTED] 1 
     
    B. ERGEBNISSE DER UNTERSUCHUNG ................................................................................. 1 
    1. Übernahme von unbeschränkten Haftungen durch das Land Kärnten .......................... 1 
    2. Verkauf der HBInt an die Bayerische Landesbank (BayernLB) ........................................ 3 
    3. Verstaatlichung der HBInt ............................................................................................... 6 
    4. Vorgehen nach der Verstaatlichung .............................................................................. 13 
     
    C. ZUSAMMENFASSUNG .................................................................................................... 17 
     
       
      1 
     A.Auftrag 
    Der Ministerrat der Republik Österreich beschloss am 25. März 2014, eine „Unabhängige 
    Untersuchungskommission zur transparenten Aufklärung der Vorkommnisse rund um die 
    Hypo Group Alpe‐Adria“ einzusetzen. Die Untersuchungskommission ([REDACTED], [REDACTED], [REDACTED], [REDACTED], [REDACTED]) hat, beginnend 
    mit 1. Mai 2014, durch Auswertung von beigeschafften Unterlagen und allgemein 
    zugänglichen Quellen sowie durch Befragung von Auskunftspersonen den maßgeblichen 
    Sachverhalt festgestellt und nach fachlichen Kriterien bewertet. 
     
    B.Ergebnisse der Untersuchung 
    1.Übernahme von unbeschränkten Haftungen durch das Land Kärnten 
    Alleinaktionärin der Hypo Alpe‐Adria‐Bank International AG (HBInt) war zunächst die 
    Kärntner Landesholding, nach dem Einstieg der Grazer Wechselseitigen Versicherung AG 
    (GRAWE) im Jahr 1992 blieb die Kärntner Landesholding Mehrheitsaktionärin. Die HBInt war 
    die Holdinggesellschaft der Hypo Group Alpe‐Adria (HGAA); die Hypo Alpe‐Adria‐Bank AG 
    (HBA) die österreichische Tochtergesellschaft der HBInt. Das Land Kärnten haftete seit 
    Gründung der Bank als [REDACTED] für die Verbindlichkeiten von HBA und HBInt. Für neue, 
    während der Übergangszeit bis zum Auslaufen der Landeshaftung (3. April 2003 bis 1. April 
    2007) eingegangene Verbindlichkeiten galt die Haftung nur, wenn die Laufzeit nicht über den 
    30. September 2017 hinausging. Die Landeshaftung war die Grundlage für das gute Rating 
    der HBInt; dadurch konnte sich die Bank zu günstigen Bedingungen auf dem Kapitalmarkt 
    refinanzieren und rasant expandieren. 2008 war die HGAA im Bank‐ und Leasinggeschäft in 
    12 Staaten mit 384 Geschäftsstellen tätig, mit einem Schwerpunkt in Südosteuropa. Ihre 
    Bilanzsumme belief sich mit 43,3 Mrd EUR auf nahezu die Hälfte der Bilanzsumme des 
    gesamten österreichischen Hypothekenbankensektors. Die Zahl der Beschäftigten stieg auf 
    mehr als 8.100. Sowohl in der HBInt als auch in den Tochtergesellschaften bestanden 
    Bonussysteme, welche starke Anreize zu Bilanzwachstum und Expansion setzten. 1
    22 
     Die HGAA expandierte in Staaten mit unterschiedlichen Rechts‐, [REDACTED] und 
    Gesellschaftssystemen, unterschiedlichen Unternehmenskulturen, verschiedenen Sprachen 
    und einer beschränkten Anzahl qualifizierter Mitarbeiter. In diesen Staaten waren die 
    rechtsstaatlichen Strukturen erst im Aufbau begriffen. Es war offenkundig, dass damit 
    besondere Anforderungen an Risikomanagementsysteme und Kontrolleinrichtungen 
    bestanden. Das Bankmanagement unterließ es, auf die Herausforderungen angemessen zu 
    reagieren. Falls es, etwa wegen unzureichender [REDACTED], nicht möglich war, 
    wirksame Risikomanagementsysteme und Kontrolleinrichtungen aufzubauen, dann hätte das 
    Wachstum den vorhandenen Ressourcen angepasst und die Risikopolitik konservativer 
    ausgerichtet werden müssen. Obwohl die Risikomanagementsysteme und die 
    Kontrolleinrichtungen den Anforderungen nicht gerecht wurden, hielten Vorstand und 
    Aufsichtsrat der HBInt an der Politik des ungebremsten Wachstums fest. 
    Es ist nicht erkennbar, dass Abschlussprüfer, Bankenaufsicht oder das Land Kärnten (die 
    Kärntner Landesholding) die ihnen offenstehenden Möglichkeiten in einem ausreichenden 
    Maß genützt hätten, um auf eine Begrenzung der Risiken hinzuwirken. 
    Die Abschlussprüfer stellten zwar regelmäßig schwere Mängel fest, zogen daraus aber nicht 
    die erforderlichen Konsequenzen. So wurden in den Prüfberichten und Management [REDACTED] 
    wiederholt Missstände im Risikomanagement, in den Kreditprozessen und im Treasury‐
    Bereich aufgezeigt. Es ist aber nicht ersichtlich, dass die festgestellten Missstände bei der 
    Beurteilung der Angemessenheit der [REDACTED] eine Rolle gespielt oder zu 
    entsprechenden Konsequenzen in der Führung der Bank geführt hätten. Der 
    Bestätigungsvermerk wurde dennoch immer erteilt; allerdings 2006, nach Bekanntwerden 
    der SWAP‐Verluste, für die Jahresabschlüsse 2004 und 2005 zurückgezogen.  
    Die OeNB prüfte die HBInt in allen Jahren vor der Verstaatlichung im Auftrag der FMA, aber 
    mit unterschiedlichen Schwerpunkten. Sie stellte wiederholt gravierende Mängel im 
    Risikomanagement und in den Kontrolleinrichtungen fest. Dennoch wurde weder intensiver 
    geprüft noch die HBInt mit dem notwendigen Nachdruck zur Behebung der [REDACTED] 
    angehalten. Die Bankenaufsicht unterließ es, ausreichend Druck auf das Management der 
    HBInt auszuüben, damit dieses entweder für eine wirksame Verbesserung der 
    Kontrollsysteme sorgte oder das Wachstum einschränkte. Bei Verstößen gegen das 3 
    4 
    5 
    6 3 
     Bankwesengesetz hätten Sanktionen verhängt werden können. Angesichts des nicht 
    abzuschätzenden [REDACTED] für die öffentliche Hand hätten allenfalls ungenügende Ressourcen 
    der Bankenaufsicht aufgestockt und zielgerichtet eingesetzt werden müssen. 
    Das Risiko für das Land Kärnten war nicht kalkulierbar, weil die Haftung für alle künftigen 
    Verbindlichkeiten von HBInt und HBA galt. Ihren Höchststand erreichte die Landeshaftung 
    2007 mit 23 Mrd EUR. Eine Inanspruchnahme als Ausfallsbürge hätte die wirtschaftliche 
    Tragfähigkeit des Landes schnell in außerordentlicher Weise überstiegen. Zwischen 2004 und 
    2011 überstieg die Landeshaftung in jedem Jahr das Bruttoinlandsprodukt Kärntens. 
    Der dramatische Anstieg der Haftung als Folge ungebremsten Wachstums führte zu höheren 
    Einnahmen für das Land in der Form von Haftungsprovisionen, die von HBInt und HBA zu 
    zahlen waren; daneben bezog das Land auch Dividenden. Der Aufsichtskommissär des 
    Landes befand sich in einem permanenten Interessenkonflikt, weil er als 
    Landesfinanzreferent an Einnahmen für das Budget interessiert war, als [REDACTED] 
    aber auf eine Begrenzung des [REDACTED] hätte hinwirken müssen. 
    Die mit der Landeshaftung verbundenen, für Kärnten letztlich nicht tragbaren Risiken aus der 
    Expansion der HGAA waren unübersehbar. Es liegt deshalb ein klarer Fall von „moral hazard“ 
    vor: Das Land rechnete offenbar damit, dass der Bund einspringen würde, sollte die Haftung 
    schlagend werden, so dass es keinen Grund sah, das Risiko zu drosseln und damit auf 
    mögliche Einnahmen zu verzichten. Was für das Land gilt, trifft auch auf die HBInt zu. Auch 
    die Bank sah keinen Anlass, das Wachstum einzuschränken, weil sie sich durch die 
    Landeshaftung zu günstigen Bedingungen refinanzieren konnte und die Höhe der 
    Haftungsprovision die Risiken nicht angemessen widerspiegelte. 
     
    2.Verkauf der HBInt an die Bayerische Landesbank (BayernLB) 
    Das rasante Wachstum verschärfte die chronische Eigenmittelknappheit der HBInt. Um 
    dringend benötigtes Kapital zu beschaffen, aber auch ebenso dringend benötigtes Know‐
    how zu gewinnen, strebte das Bankmanagement eine strategische Partnerschaft mit 
    anderen Banken an. Nachdem entsprechende Kontakte nicht zum gewünschten Erfolg 7 
    8 
    9 
    10 4 
     geführt hatten, wurde 2005 beschlossen, die HBInt in naher Zukunft an die Börse zu bringen. 
    Im Vorgriff auf die erwarteten Erlöse aus dem Börsegang begab die Kärntner Landesholding 
    2005 eine Pre‐IPO‐Umtauschanleihe über 500 Mio EUR. Grund dafür war, dass das Land das 
    Sondervermögen „Zukunft Kärnten“ bereits zum damaligen Zeitpunkt errichten wollte und 
    für dieses Projekt den Erlös aus der Umtauschanleihe benötigte. Die Anleihe musste 
    spätestens 2008 in Aktien umgetauscht oder zurückgezahlt werden. 
    Das Bekanntwerden der SWAP‐Verluste im März 2006 machte die Hoffnung auf einen 
    raschen Börsegang zunichte. Sowohl für die Kärntner Landesholding als auch für die HBInt 
    war der Druck groß, auf andere Weise Kapital zu beschaffen: Die Kärntner Landesholding 
    musste die Anleihe zurückführen, die HBInt musste ihr Kapital – auch infolge der SWAP‐
    Verluste – aufstocken. 
    Um Investoren zu gewinnen, wurde die HBInt auf „Roadshows“ potenziellen Kapitalgebern 
    vorgestellt und ein Bieterverfahren durchgeführt. Die Berlin & Co Capital S.à.r.l. setzte sich 
    im Bieterverfahren durch, weil sie einen höheren Preis bot als die anderen Interessenten. 
    Dass es überhaupt zu einem Bieterverfahren kam, war darauf zurückzuführen, dass weder 
    die Kärntner Landesholding noch die Minderheitsaktionärin GRAWE bereit war, die 
    notwendige Kapitalerhöhung von 250 Mio EUR zu finanzieren. Wären sie dazu bereit 
    gewesen und hätten sie die Anteile in der Folge an die BayernLB verkaufen können, so 
    hätten sie den Gewinn realisieren können, den die Berlin & Co Capital S.à.r.l. durch den 
    Weiterverkauf der Anteile erzielte. 
    Die Untersuchung hat keine Anhaltspunkte ergeben, dass die BayernLB schon vor dem 
    Anteilserwerb durch die Berlin & Co Capital S.à.r.l. zugesichert hätte, einen Mehrheitsanteil 
    an der HBInt übernehmen zu wollen. Sowohl dem von der Berlin & Co Capital S.à.r.l. als auch 
    dem in der Folge von der BayernLB gezahlten Preis lagen Unternehmenswertgutachten 
    zugrunde, die auf anerkannten Bewertungsmethoden beruhten. Die in den Gutachten 
    festgestellten Bandbreiten für den Unternehmenswert hingen ganz wesentlich davon ab, wie 
    die Zukunftsaussichten der HGAA beurteilt und welche Erträge in Zukunft erwartet wurden. 
    Der Erwerb der Mehrheit der Aktien der HBInt durch die BayernLB ist dadurch 
    gekennzeichnet, dass die BayernLB die Bank „um jeden Preis“ haben wollte und sogar bereit 11 
    12 
    13 
    14 5 
     war, zusätzlich zum Kaufpreis von 1,625 Mrd EUR für 50 % + 1 Aktie den [REDACTED] Fußball mit 
    2,5 Mio EUR zu „sponsern“, um Landeshauptmann [REDACTED] für den Verkauf zu gewinnen. Die 
    BayernLB muss davon überzeugt gewesen sein, dass sie vom Netzwerk der HGAA in 
    Südosteuropa ganz erheblich profitieren würde, so dass die bei der [REDACTED] 
    hervorgekommenen [REDACTED] vernachlässigbar erschienen. Das ist auch eine mögliche 
    Erklärung dafür, dass die BayernLB trotz offenkundiger [REDACTED] nicht auf den in solchen 
    Fällen üblichen Gewährleistungsvereinbarungen bestand.  
    Für die Kärntner Landesholding bedeutete der Mehrheitserwerb durch die BayernLB, dass 
    sie ihren bestimmenden Einfluss auf die HBInt verlor, die Landeshaftung für die am 1. April 
    2007 bestehenden Verbindlichkeiten aber weiter aufrecht blieb. Damit waren die – 
    allerdings bisher ohnehin nicht genützten – Möglichkeiten der Kärntner Landesholding 
    entscheidend geschwächt, auf eine Begrenzung des [REDACTED] einer Inanspruchnahme des 
    Landes aus der Landeshaftung hinzuwirken. Wie groß das Risiko war, hing von der weiteren 
    Entwicklung der HGAA ab. Denn die Entwicklung – und nicht die Finanzstärke der BayernLB – 
    war ausschlaggebend dafür, ob die HBInt in der Lage sein würde, ihre Verbindlichkeiten bei 
    Fälligkeit zu erfüllen und damit zu verhindern, dass die Landeshaftung schlagend wird. 
    Die BayernLB hielt zunächst am Kurs ungebremsten Wachstums fest. So stieg die 
    Bilanzsumme von 31 Mrd EUR Ende 2006 auf 43,3 Mrd EUR Ende 2008; im Zeitpunkt der 
    Verstaatlichung betrug sie – bei durch die Landeshaftung gesicherten Verbindlichkeiten von 
    20,1 Mrd EUR – 41 Mrd EUR. Das Risiko einer Inanspruchnahme des Landes aus der Haftung 
    nahm damit weiter zu, da die schweren Mängel des Risikomanagements und der 
    Kontrolleinrichtungen keineswegs behoben waren. 
    Die durch den Verkauf des Landesanteils erzielte Einnahme von 809 Mio EUR für das Land 
    Kärnten wird dadurch entscheidend relativiert. Mit dem Verkauf eines Mehrheitsanteils an 
    die BayernLB waren die Probleme der Kapitalknappheit und des fehlenden Know‐how auch 
    nur scheinbar gelöst. Zwar erhielt die HBInt einen kapitalstarken Mehrheitseigentümer, der 
    die Bank mit dem notwendigen Kapital ausstatten würde und auch über das Know‐how 
    verfügte, das erforderlich war, um Risikomanagement und Kontrolleinrichtungen auf einen 
    dem Geschäftsumfang angemessenen Standard zu bringen; die Kärntner Landesholding 
    erhielt die Mittel, um die Umtauschanleihe zurückführen zu können. 15 
    16 
    17 6 
     Dass damit die Probleme doch nicht gelöst waren, liegt nicht an den Umständen, unter 
    denen der Aktienkauf durch die BayernLB zustande kam. Ein wesentlicher Grund war, dass 
    die Haftung des Landes Kärnten für die Verbindlichkeiten von HBInt und HBA aufrecht blieb. 
    Das bedeutete bei gesicherten Verbindlichkeiten von 23 Mrd EUR im Zeitpunkt des 
    Aktienverkaufs, dass die BayernLB an die Verantwortung der Republik Österreich (des 
    Bundes) appellieren konnte, als die HBInt infolge eines sprunghaften Anstiegs des 
    Wertberichtigungsbedarfs weiteres Kapital brauchte, obwohl die HBInt nunmehr die 
    österreichische Tochter einer bayerischen Bank war. 
     
    3.Verstaatlichung der HBInt 
    Die BayernLB setzte den Wachstumskurs bis September 2008 fort. Nach einer 
    Kapitalerhöhung um 600 Mio EUR im Jahr 2007, die von der BayernLB und der GRAWE 
    getragen wurde, und einer weiteren Kapitalerhöhung um 700 Mio EUR im Jahr 2008, die fast 
    zur Gänze von der BayernLB getragen wurde, stellte die HBInt am 15. Dezember 2008 den 
    Antrag auf Zeichnung von Partizipationskapital von 1,45 Mrd EUR durch den Bund. In einem 
    vom BMF angeforderten Gutachten hatte die OeNB zu beurteilen, ob die HBInt grundsätzlich 
    gesund („sound“) oder nicht grundsätzlich gesund („distressed“) war. Die OeNB kam zum 
    Schluss, dass die HBInt „nicht ‚distressed’ im Sinne unmittelbar erforderlicher 
    Rettungsmaßnahmen[REDACTED] sei. Damit erfüllte die OeNB ihre Aufgabe nicht. Das BMF 
    verabsäumte es, eine eindeutige Beurteilung einzufordern und gewährte der HBInt 
    Partizipationskapital von 900 Mio EUR zu den Bedingungen für grundsätzlich gesunde 
    Banken. Bei einer Qualifikation als „distressed“ wäre die Verzinsung höher gewesen; eine 
    solche Qualifikation hätte aber vor allem bewirkt, dass die HBInt bereits damals einen 
    Umstrukturierungsplan hätte entwickeln müssen. Mit der Gewährung des 
    Partizipationskapitals zu den Bedingungen für gesunde Banken wurde eine weitere 
    Gelegenheit verpasst, die Bank zur Lösung ihrer strukturellen Probleme anzuhalten. 
    Das BMF traf die Entscheidung zur Verstaatlichung der HBInt vom 14. Dezember 2009 in 
    Abstimmung mit dem Bundeskanzleramt gestützt auf Empfehlungen und Handlungen 
    anderer Akteure. Für die Bewertung dieser Maßnahmen sind Grundsätze maßgebend, wie 18 
    19 
    20 7 
     sie für unternehmerische Entscheidungen mit der Business Judgment [REDACTED] entwickelt 
    wurden. Danach kommt es darauf an, ob das in der konkreten Situation gebotene Verfahren 
    durchgeführt wurde, ob für die Entscheidung eine angemessene Informationsgrundlage 
    bestand und ob die Entscheidung frei von Interessenkonflikten zustande kam. 
    Zentrale Frage in diesem Zusammenhang ist, ob das BMF die notwendigen Informationen 
    rechtzeitig beschaffte und die Entscheidung zur Verstaatlichung aufgrund ausreichender 
    Vorbereitung traf. 
    Akute Probleme der HBInt wurden offenkundig, als sich aufgrund des 
    Halbjahresfinanzberichts 2009 herausstellte, dass die [REDACTED] bereits das für das 
    gesamte Kalenderjahr veranschlagte Ausmaß erreicht hatte. Auch die 
    Finanzmarktbeteiligung AG des Bundes (FIMBAG) wies in einer am 22. Juli 2009 an das BMF 
    übermittelten Stellungnahme sowohl auf den „dramatischen Anstieg“ des 
    Wertberichtigungsbedarfs als auch auf unrealistische Planungsannahmen der HBInt hin. Die 
    Europäische Kommission hatte in ihrer Entscheidung zur Eröffnung des – wegen der mit dem 
    Partizipationskapital gewährten Staatshilfe aufgrund europarechtlicher Vorgaben notwendig 
    gewordenen – [REDACTED] vom 12. Mai 2009 klargestellt, dass sie die HBInt nicht als 
    „sound“ einstufte. Die OeNB teilte am 15. Mai 2009 mit, dass sie die HBInt als „distressed“ 
    beurteilt hätte, wäre die von der BayernLB im Dezember 2009 durchgeführte 
    Kapitalerhöhung nicht zu berücksichtigen gewesen.  
    Das BMF musste aufgrund der im Juli 2009 bekannt gewordenen unerwartet hohen 
    [REDACTED] damit rechnen, dass neues Kapital erforderlich sein könnte. Zudem hatte die 
    OeNB in einer Analyse vom 25. Mai 2009 darauf hingewiesen, dass die HBInt aufgrund der 
    wirtschaftlichen Lage der BayernLB gezwungen sei, neben der BayernLB andere 
    Finanzierungsquellen zu erschließen. 
    Für das BMF musste damit klar sein, dass die Lage der HBInt deutlich schlechter als zuvor 
    angenommen war. Aufgrund der vom Vorstandsvorsitzenden [REDACTED] erteilten Information 
    musste das BMF davon ausgehen, dass die BayernLB nicht allein für die notwendige 
    Rekapitalisierung sorgen würde. Jedenfalls zu diesem Zeitpunkt hätten daher strategische 21 
    22 
    23 
    24 8 
     Überlegungen über das weitere Vorgehen angestellt und schriftlich festgehalten werden 
    müssen.  
    Ein solches Strategiepapier ist der Untersuchungskommission trotz mehrfacher Nachfragen 
    nicht vorgelegt worden. Die Untersuchung hat auch nicht ergeben, dass das BMF mit den 
    Minderheitsaktionären Kontakt aufgenommen hätte. Fest steht nur, dass die FMA versuchte, 
    von der BayernLB Zusagen über die Rekapitalisierung der HBInt zu bekommen, aber keine 
    konkrete Auskunft erhielt. Fest steht auch, dass es am 20. November 2009 zu 
    Telefongesprächen zwischen Finanzminister Pröll und dem bayerischen Staatsminister 
    Fahrenschon kam, deren Gegenstand die Kapitalaufbringung war.  
    Weiters steht fest, dass die BayernLB dem BMF am 23. November 2009 vorschlug, der Bund 
    solle ihre Aktien an der HBInt kaufen. Der Bund hätte spätestens zu diesem Zeitpunkt auf 
    Basis der eigenen Ziele Verhandlungen mit dem Freistaat Bayern und der BayernLB, aber 
    auch mit den Minderheitsaktionären vorbereiten müssen. Er kann sich daher nicht darauf 
    berufen, dass die dafür notwendige Zeit nicht zur Verfügung gestanden wäre.  
    Um die Verhandlungen zielgerichtet vorzubereiten, wäre es notwendig gewesen, in einem 
    Strategiepapier die Stärken und Schwächen der Positionen aller beteiligten Akteure zu 
    analysieren und Szenarien zu entwickeln, die der Bund seinerseits hätte vorschlagen und 
    verfolgen können. Trotz der Bedeutung der anstehenden Verhandlungen wurden aber 
    weder zeitgerecht die notwendigen Informationen beschafft noch wurden 
    Alternativszenarien zur Insolvenz entwickelt. Zwar richtete die Finanzprokuratur als 
    Vertreterin des Bundes Anfragen an FMA und OeNB. Diese Anfragen waren jedoch nicht 
    primär darauf gerichtet, Informationen zu erhalten, die für die Erarbeitung einer 
    Verhandlungsposition des Bundes von Bedeutung gewesen wären. Die Anfrage an die FMA 
    bezog sich ausschließlich darauf, welche Aufsichtsschritte in der Vergangenheit gesetzt 
    worden waren. Die Anfrage an die OeNB bezog zwar die wirtschaftliche Situation der HBInt 
    und die Auswirkungen einer Insolvenz mit ein; sie war aber auch insoweit auf die 
    Vergangenheit gerichtet, als die OeNB aufgefordert wurde, zu den Ursachen des 
    Vermögensverfalls Stellung zu nehmen. Für die Verhandlungsstrategie des Bundes war die 
    Anfrage der Finanzprokuratur nur insoweit von Bedeutung, als von der OeNB Informationen 
    über den derzeitigen Zustand der HBInt erwartet werden konnten. Die OeNB verwies auf 25 
    26 
    27 9 
     Mängel im Kreditvergabeprozess, in der Überwachung der Kreditnehmer, in der Bewertung 
    der Sicherheiten und bei der Bildung der Risikovorsorge. Besonders aussagekräftig in diesem 
    Zusammenhang ist der Bericht der OeNB vom 23. November 2009, der eine umfangreiche 
    Liste von gravierenden Mängeln in allen wesentlichen Bereichen enthält. Dem BMF war 
    bekannt, dass es den Bericht gab. 
    Dass diese Information genutzt worden wäre, ist nicht ersichtlich. Denn trotz der in den 
    Berichten der OeNB beschriebenen gravierenden Missstände und trotz der Tatsache, dass 
    keine [REDACTED] durchgeführt worden war, verzichtete der Bund auf jede 
    Gewährleistung für einen bestimmten Zustand der HBInt. Damit ging der Bund ein sehr 
    hohes Risiko ein. Eine allfällige – in den Aktienkaufverträgen nicht ausdrücklich 
    ausgeschlossene – Vertragsanfechtung wegen Irreführung ist kein vollwertiger Ersatz, weil 
    sie an Voraussetzungen geknüpft ist, die über [REDACTED] der gekauften Sache hinausgehen. 
    Bei sorgsamer Informationsaufbereitung hätten die Vertreter des Bundes auch erkannt, dass 
    und in welchem Maß die Verhandlungsposition der BayernLB durch die offenen Forderungen 
    gegen die HBInt geschwächt war. Nach den bei der Verwaltungsratsklausur der BayernLB am 
    28. und 29. November getätigten Aussagen beliefen sich die Refinanzierungslinien auf 5 Mrd 
    EUR; nach den Angaben der HBInt vom 7. Dezember 2009 auf 3,5 Mrd EUR; die OeNB ging in 
    einer Aufstellung vom Dezember 2009 von Liquiditätslinien von 3 Mrd EUR aus; im Zeitpunkt 
    der Verstaatlichung sollen es 3,7 Mrd EUR gewesen sein. Das Gesamtrisikovolumen der 
    BayernLB lag damit, Kaufpreis und bisherige Kapitalaufstockungen mit eingerechnet, 
    zwischen rund 6 Mrd EUR und 8,2 Mrd EUR. 
    Mit der Kündigung von Darlehen am 11. Dezember 2009 und der Aufrechnung mit fälligen 
    Ansprüchen der HBInt versuchte die BayernLB, ihr Risiko um 600 Mio EUR zu reduzieren. 
    Kündigung und Aufrechnung verschärften die Liquiditätslage der HBInt, die durch 
    Einlagenabflüsse bereits entscheidend geschwächt war. Ausgelöst wurden die 
    Einlagenabflüsse durch die anhaltende negative Medienberichterstattung. Es ist nicht 
    erkennbar, dass der Bund eine Kommunikationsstrategie verfolgt oder zumindest versucht 
    hätte, mit der HBInt und der BayernLB gemeinsam eine solche Strategie zu entwickeln. Dabei 
    muss auch der Interessenkonflikt beachtet werden, in dem sich der Vorstandsvorsitzende 
    der HBInt befand. Einerseits hätte er alles tun müssen, um die für die Bank katastrophale 28 
    29 
    30 10 
     Berichterstattung zu verhindern. Andererseits trugen die Folgen dieser Berichterstattung 
    dazu bei, dass die BayernLB ihrem Ziel näher kam, eine Übernahme durch den Bund zu 
    erreichen. Gegen deren allfällige negative Auswirkungen auf seinen Vorstandsvertrag hatte 
    sich der Vorstandsvorsitzende abgesichert. 
    Im Aktienkaufvertrag zwischen dem Bund und der BayernLB anerkannte die HBInt 
    ausdrücklich die Rechtswirksamkeit der Kündigung und der Aufrechnung. Es hätten freilich 
    rechtliche Ansatzpunkte dafür bestanden, dies in Zweifel zu ziehen. So hatte die BayernLB 
    die Darlehenskündigung auf das Master Loan Agreement (Rahmenkreditvertrag vom 30. 
    Jänner 2008) gestützt, ohne anzugeben, welchen vertraglichen Kündigungsgrund sie als 
    erfüllt ansah. Ohne wirksame Kündigung hätte auch keine Aufrechnungslage bestanden. Die 
    Aufrechnung hätte, im Fall einer Insolvenzeröffnung, wegen Begünstigung nach § 30 
    Insolvenzordnung angefochten werden können. 
    Hätte sich das BMF über all diese Umstände informiert, so hätte sich die Annahme, dass die 
    BayernLB eine Insolvenz der HBInt in Kauf nehmen würde, in einem neuen Licht gezeigt. 
    Zumindest hätten die Vertreter des Bundes auf die der BayernLB drohenden [REDACTED] 
    hinweisen und damit ihre Verhandlungsposition stärken können. Eine Prüfung der von der 
    BayernLB gewährten Darlehen nach Eigenkapitalersatzrecht hätte den österreichischen 
    Verhandlern auch erlaubt, den wirtschaftlichen Wert der von der BayernLB angebotenen 
    Leistungen einzuschätzen. Die Versäumnisse des Bundes liegen somit in einer mangelnden 
    Informationsbeschaffung, in der fehlenden strategischen Planung und in der fehlenden 
    Umsetzung der bekannten Informationen in eine Verhandlungsstrategie. 
    Schließlich ist darauf hinzuweisen, dass im Aktienkaufvertrag zwischen dem Bund und der 
    BayernLB die Gewährung von Liquidität zu den gleichen Bedingungen erfolgte, zu denen die 
    am 11. Dezember 2009 von der BayernLB gekündigten Darlehen gewährt worden waren. 
    Diese Vertragsbedingungen ergeben sich aus dem Master [REDACTED]. Sie enthalten die 
    Zusage des Kreditnehmers (der HBInt), näher bezeichnete gesellschaftsrechtliche 
    Umstrukturierungen nur mit vorheriger schriftlicher Zustimmung des Kreditgebers (der 
    BayernLB) durchzuführen. Gleichzeitig sagte der Bund für den Fall der „Aufspaltung der Bank 
    oder einer wirtschaftlich vergleichbaren Maßnahme, nach der die Lebensfähigkeit der Bank 
    nicht mehr gewährleistet ist“, zu, die Rückzahlung der zu diesem Zeitpunkt aushaftenden 31 
    32 
    33 11 
     Darlehen und Kreditlinien der BayernLB sicherzustellen. Durch diese Vertragsgestaltung 
    wurden gesellschaftsrechtliche Umstrukturierungen von der Zustimmung der BayernLB 
    abhängig gemacht, obwohl der Bund nach dem Aktienkaufvertrag für einen solchen Fall 
    ohnehin die Kreditrückzahlung an die BayernLB garantierte. Es gibt keine Hinweise, dass dies 
    den Personen, die für den Bund handelten, bei den Verstaatlichungsverhandlungen, bei der 
    Vertragserrichtung oder bei Vertragsabschluss bewusst gewesen wäre. 
    Anders als das BMF, das auf die Beauftragung externer Spezialisten des [REDACTED]‐ und 
    Insolvenzrechts verzichtete, setzte sich der Verwaltungsrat der BayernLB unter Beiziehung 
    von (auch österreichischen) Experten mit Eigenkapitalersatzrecht und Insolvenzrecht 
    auseinander und schuf mit der Kündigung von Darlehen und der Aufrechnung mit 
    Forderungen der HBInt Tatsachen. Beide Maßnahmen, Darlehenskündigung und 
    Aufrechnung, wären bei der von der BayernLB angedrohten Insolvenzeröffnung anfechtbar 
    gewesen und hätten rückgängig gemacht werden müssen. Die im Kaufvertrag vereinbarte 
    Gewährung von Liquidität im Umfang und zu den Bedingungen der gekündigten Darlehen 
    war daher in Wahrheit kein Zugeständnis. Das gilt auch für den Verzicht der BayernLB auf 
    300 Mio EUR Ergänzungskapital, denn auch das Ergänzungskapital wäre bei einer 
    Insolvenzeröffnung verloren gewesen. 
    Letztlich hat die BayernLB nur auf ein Darlehen von 525 Mio EUR verzichtet, das 
    möglicherweise ohnehin als eigenkapitalersetzend zu werten und damit einer 
    Rückzahlungssperre unterworfen gewesen wäre; die BayernLB hätte dafür, wie für ihre 
    gesamten Einlagen, in einem Insolvenzverfahren nur die Insolvenzquote erhalten. Der 
    BayernLB ist es aber gelungen, durch diesen Verzicht die Werthaltigkeit ihrer Forderungen 
    gegen die HBInt von mehreren Milliarden EUR zu bewahren. Denn der Bund garantierte die 
    Rückzahlung, sollte die Lebensfähigkeit der HBInt infolge einer Aufspaltung oder 
    wirtschaftlich vergleichbaren Maßnahme nicht mehr gewährleistet sein. 
    Bei der von ihr angedrohten Insolvenz standen für die BayernLB jedenfalls mehr als 6 Mrd 
    EUR auf dem Spiel; nach dem Bericht über die Ergebnisse der Verwaltungsratsklausur waren 
    es sogar mehr als 8 Mrd EUR. Für den Bund bestand die Gefahr, für das Land Kärnten 
    einspringen zu müssen, sollte die Landeshaftung von damals rund 20 Mrd EUR schlagend 
    werden. Wie viel Geld das Land Kärnten (im Ergebnis der Bund) letztlich aufzuwenden 34
    35 
    3612 
     gehabt hätte, hing davon ab, wie hoch der Ausfall nach Einziehung aller Forderungen und 
    Verwertung aller sonstigen Vermögenswerte der HBInt gewesen wäre. Was den 
    Reputationsverlust betrifft, war die Lage für den Bund jedenfalls nicht schlechter als für den 
    Freistaat Bayern als dem wirtschaftlichen Eigentümer der BayernLB und für Deutschland. 
    Die österreichischen Verhandler machen geltend, dass der Bund wegen der Kärntner 
    Landeshaftungen gezwungen war, die Anteile an der HBInt zu kaufen. Diese Argumentation 
    ist nicht vereinbar mit der vergleichsweise geringen Höhe des mit dem Land Kärnten 
    vereinbarten Beitrags. Wird berücksichtigt, dass das Land Kärnten 2009 im Zukunftsfonds 
    noch über rund 667 Mio EUR verfügte, nachdem es durch den Verkauf der HBInt‐Aktien an 
    die BayernLB 809 Mio EUR eingenommen hatte, so war der vom Land Kärnten zu leistende 
    Beitrag – Umwandlung von 50 Mio EUR Ergänzungskapital in Partizipationskapital und 
    Zeichnung von 150 Mio EUR Partizipationskapital durch die Kärntner Landesholding – 
    unverhältnismäßig gering. Dies vor allem dann, wenn man bedenkt, dass das Recht des 
    Landes auf den Bezug von Haftungsprovision im Zuge der Verstaatlichung nicht beseitigt 
    worden war, weshalb das Land auch noch für das Jahr 2010 knapp 19,5 Mio EUR an 
    Haftungsprovision erhielt. Auch für 2011 standen dem Land 18 Mio EUR zu. Dass dem Land 
    Kärnten weiterhin Haftungsprovision zufloss, obwohl es nicht in der Lage gewesen wäre, 
    seine Verpflichtungen aus der Landeshaftung zu erfüllen und obwohl die HBInt mittlerweile 
    im Eigentum des Bundes stand, ist nicht nachvollziehbar. 
    Bei Berücksichtigung all dieser Umstände kommt die Untersuchungskommission zum 
    Ergebnis, dass die verantwortlichen Entscheidungsträger des Bundes die 
    Verstaatlichungsentscheidung ohne ausreichende Informationsgrundlage getroffen haben. 
    Sie haben weder die Tatsachen angemessen aufbereitet noch die rechtlichen 
    Rahmenbedingungen ausreichend geprüft. Damit konnten die österreichischen Verhandler 
    keine Alternativszenarien entwickeln, die ein Gegengewicht zur Strategie der BayernLB und 
    des [REDACTED] hätten bilden können. Der Gegenseite war es dadurch möglich, Gang 
    und Ergebnis der Verhandlungen maßgeblich zu bestimmen. Dies gilt sowohl für die 
    Verstaatlichung als solche als auch für die Bedingungen, zu denen die Verstaatlichung 
    erfolgte. 37 
    38 13 
     Vor diesem Hintergrund kann die Verstaatlichung nicht als „Notverstaatlichung“ bezeichnet 
    werden, denn sie war – zumindest in ihrer Ausgestaltung – keineswegs alternativlos.  
    4.Vorgehen nach der Verstaatlichung 
    Nach der Verstaatlichung fehlte eine klare Strategie. Einerseits sollte die HBInt saniert und 
    dann wieder privatisiert werden, andererseits sollte die Vergangenheit aufgearbeitet 
    werden. Gleichzeitig musste aber erreicht werden, dass die Europäische Kommission im 
    Beihilfeverfahren die Staatshilfen für die HBInt genehmigte. Dabei ließ die Europäische 
    Kommission von Anfang an keinen Zweifel daran, dass sie größte Bedenken gegen das 
    Geschäftsmodell der HBInt hatte und die Errichtung einer Abbaueinheit erwartete. Die 
    Errichtung einer Abbaueinheit wäre auch die Voraussetzung dafür gewesen, dass sich die 
    Europäische Bank für Wiederaufbau und Entwicklung EBRD und die International Financial 
    Corporation IFC an der Restrukturierung beteiligt hätten. 
    Dennoch haben es die politischen Entscheidungsträger abgelehnt, eine Abbaulösung auch 
    nur zu erwägen. Grund dafür war, dass eine Abbaueinheit im Staatseigentum die 
    Staatsschuld erhöht hätte. Die politischen Entscheidungsträger nahmen damit in Kauf, dass 
    das Beihilfeverfahren wesentlich länger dauerte als vergleichbare Verfahren und das 
    Hinauszögern einer Lösung auch dazu führen konnte, dass die öffentliche Hand und damit 
    die Allgemeinheit letztlich mit noch höheren Kosten belastet wird. 
    Jede Restrukturierung der HGAA setzte voraus, dass das Beihilfeverfahren mit einer 
    Genehmigung der Staatshilfen abgeschlossen würde. Die Ergebnisse des Beihilfeverfahrens 
    waren damit ausschlaggebend dafür, welche Maßnahmen getroffen werden konnten, um 
    die Belastung für die öffentliche Hand möglichst gering zu halten. Indes haben die 
    politischen Entscheidungsträger offenbar die Bedeutung des Beihilfeverfahrens nicht 
    erkannt. Anders lässt sich ihr mangelnder Einsatz nicht erklären. 
    Ein enger Kontakt mit den zuständigen Stellen in der Europäischen Kommission, vor allem 
    mit dem [REDACTED] selbst, wäre unabdingbar gewesen, um eine rasche 
    Entscheidung und gute Bedingungen zu erreichen. Wie das Beispiel anderer Mitgliedstaaten, 
    deren Banken Staatshilfe erhalten hatten, zeigt, wäre dieses Vorgehen nicht nur absolut 
    üblich gewesen. Die Europäische Kommission erwartet vielmehr, dass nationale Regierungen 39 
    40 
    41 
    42 
    43 14 
     auf diese Art kooperieren. Dass in Brüssel mit Erstaunen registriert wurde, wie gering das 
    Engagement der österreichischen Bundesregierung war, spricht für sich. Es ist auch nicht 
    erkennbar, dass der Bund kompetente juristische Beratung in Anspruch genommen und eine 
    Strategie für das Beihilfeverfahren entwickelt hätte. Die Bundesregierung wollte offenbar 
    nicht zur Kenntnis nehmen, dass sie mit der Verstaatlichung die Verantwortung für die HBInt 
    und damit auch für das Beihilfeverfahren übernommen hatte. Eine allfällige Untätigkeit oder 
    Unwilligkeit der [REDACTED], die notwendigen Unterlagen zu liefern, könnte daher den Bund 
    nicht entlasten, sondern hätte durch geeignete Maßnahmen abgestellt werden müssen. 
    Ebenso wenig kann den Bund entlasten, dass eine staatliche Abbaueinheit die [REDACTED] 
    erhöht hätte. Den negativen Auswirkungen einer staatlichen Bad Bank für die Höhe der 
    Staatsschuld hätten die Nachteile des [REDACTED] einer Abbaulösung für das 
    Beihilfeverfahren und auch die mögliche höhere finanzielle Belastung des Bundes gegenüber 
    gestellt werden müssen. Eine solche Abwägung wurde offenbar nicht vorgenommen. 
    Bezeichnend in diesem Zusammenhang ist, dass die an die Errichtung einer Bad Bank 
    geknüpfte Chance einer Einbeziehung von EBRD und IFC in die Sanierung des Südosteuropa‐
    Netzwerks nicht genutzt wurde, obwohl die Vorteile klar auf der Hand lagen. Die Fixierung 
    auf die Auswirkungen für die [REDACTED] verhinderte damit eine Lösung, die geeignet 
    gewesen wäre, das Südosteuropa‐Netzwerk als einen der wenigen noch verbliebenen 
    Vermögenswerte der HBInt zu erhalten. 
    Eine weitere grundlegende Fehleinschätzung betraf die Aufarbeitung der Vergangenheit. Es 
    ist nachvollziehbar, dass der Bund daran interessiert war, die Ursachen des rasanten 
    Vermögensverfalls der HBInt festzustellen. Immerhin war die HBInt im Zeitpunkt des 
    Verkaufs der Mehrheit der Aktien an die BayernLB noch mit 3,2 Mrd EUR bewertet worden 
    und schon ein Jahr später hatte sie Staatshilfe gebraucht. Nach einem weiteren Jahr, 2009, 
    ging der Bund davon aus, die Bank nur durch Verstaatlichung vor der drohenden Insolvenz 
    retten zu können. Auch dass fehlbares Verhalten vor der Verstaatlichung zivil‐ und 
    strafrechtlich geahndet werden sollte, ist positiv zu werten. Die Aufarbeitung der 
    Vergangenheit war daher ein legitimes Ziel. 
    Der Umfang und die Art und Weise, wie die Aufarbeitung durchgeführt wurde, war aber mit 
    dem weitaus wichtigeren Ziel unvereinbar, die HBInt als lebendes, fortzuführendes 44 
    45 
    46 15 
     Unternehmen weiter zu betreiben und, jedenfalls nach den ursprünglichen Vorstellungen, zu 
    sanieren und wieder zu privatisieren. Das Vorgehen der Verantwortlichen ist ohne Beispiel, 
    und das gilt sowohl bei einem Vergleich mit anderen österreichischen Banken, die Staatshilfe 
    bekamen und umstrukturiert werden mussten, als auch im internationalen Vergleich. Dabei 
    zeigte sich schon nach kurzer Zeit, dass das Projekt „Aufarbeitung der Vergangenheit[REDACTED] den 
    Weiterbetrieb der Bank und die notwendige Umstrukturierung massiv behinderte. Die 
    Warnungen der [REDACTED] blieben ungehört; der Vorwurf, sie wollten unrechtmäßiges 
    oder gar strafbares Verhalten vertuschen, war nicht stichhaltig, denn sowohl Aufsichtsrat als 
    auch Vorstand hatten ihre Aufgaben erst nach der Verstaatlichung übernommen. 
    Dass sich die auf diese Weise betriebene Aufarbeitung der Vergangenheit für die HBInt in 
    mehrfacher Hinsicht katastrophal auswirken musste, war offenkundig. Schon die 
    Bezeichnung „CSI Hypo“ war für eine Bank in hohem Maß geschäftsschädigend, denn sie 
    brachte die Bank mit kriminellen Machenschaften in Verbindung. 
    Die Finanzprokuratur nutzte ihre starke Stellung im für die Aufarbeitung der Vergangenheit 
    eingerichteten Lenkungsausschuss in der Weise, dass während der gesamten Tätigkeit der 
    CSI Hypo kaum Entscheidungen getroffen wurden. Dass staatliche Beamte sich in dieser 
    Weise in die Geschäftsführung einer Bank einmischen, ist auch international einmalig. Das 
    BMF hätte dem rechtzeitig Einhalt gebieten müssen. 
    Geschadet hat der HBInt auch der enorme Aufwand, welchen die Aufarbeitung der 
    Vergangenheit verursachte. Bankmitarbeiter konnten ihre eigentlichen Aufgaben nicht im 
    notwendigen Maß wahrnehmen, weil sie Auskünfte erteilen und Nachforschungen anstellen 
    mussten. Dadurch wurde der Geschäftsbetrieb gestört; die Restrukturierung von Krediten 
    wurde durch die Entscheidungsprozesse im Lenkungsausschuss behindert, wenn nicht gar 
    unmöglich gemacht. Dazu kam die Verunsicherung der Mitarbeiter durch die Kritik der 
    Finanzprokuratur, die Aufarbeitung werde nicht mit vollem Einsatz betrieben und 
    Mitarbeiter könnten zum Schadenersatz verpflichtet sein.  
    Zu den internen Belastungen und Kosten kamen die Kosten für die externen Berater. Für sie 
    tat sich mit der Aufarbeitung der Vergangenheit ein äußerst profitables und in seinem 
    Umfang und in seinen Erweiterungsmöglichkeiten bisher nicht gekanntes Geschäftsfeld auf. 47 
    48 
    49 
    50 16 
     Sie nutzten es auch ausgiebig, wie die Gesamtkosten von mehr als 60 Mio EUR zeigen. 
    Diesen Kosten stehen nur bescheidene Rückflüsse gegenüber. Dass die Tätigkeit der CSI die 
    Verhandlungsposition der Bank bei Forderungen von 130 Mio EUR gestärkt haben soll, ist 
    nicht nachvollziehbar. Dann bleiben nur 2 Mio EUR an rechtskräftig zugesprochenen 
    Schadenersatzsummen und knapp 26 Mio EUR an tatsächlich rückgeführten 
    Vermögenswerten. 
    Die Bestellung des Beauftragten Koordinators im Mai 2012 bereinigte zwar die durch die 
    Auseinandersetzungen zwischen Bankorganen und Finanzprokuratur unhaltbar gewordene 
    Situation; sie führte aber auch dazu, dass der Umfang der Aufarbeitung noch ausgedehnt 
    wurde. Denn auch nach Auffassung des Beauftragten Koordinators hatten wirtschaftliche 
    Erwägungen bei der Aufarbeitung der Vergangenheit keine Rolle zu spielen. Es ist auch 
    einmalig, dass eine lebende, fortzuführende Bank die Aufarbeitung der Vergangenheit in 
    ihrer Satzung zum Unternehmenszweck erklärt. 
    Es fehlte somit auch nach der Verstaatlichung an einer Strategie, wie die Interessen des 
    Bundes am besten gewahrt werden können. Wäre eine solche Strategie ausgearbeitet 
    worden, so wäre offensichtlich geworden, dass die Restrukturierung der HGAA ohne weitere 
    Verzögerung in Angriff genommen und das Beihilfeverfahren mit größtem Einsatz betrieben 
    werden muss. Offensichtlich wäre auch geworden, dass eine Aufarbeitung der 
    Vergangenheit, die wirtschaftliche Erwägungen ausklammert, nur Einzelinteressen dient, die 
    Bank aber schädigt und die finanzielle Belastung für den Bund weiter erhöht. 
    Die Untersuchungskommission kommt zum Ergebnis, dass die verantwortlichen 
    Entscheidungsträger des Bundes nach der Verstaatlichung Entscheidungen getroffen haben, 
    ohne über eine ausreichende Informationsgrundlage zu verfügen und ohne das erforderliche 
    Fachwissen beschafft zu haben: Das Beihilfeverfahren wurde nicht mit dem notwendigen 
    fachlichen und politischen Einsatz betrieben; die Entscheidung über eine Abbaulösung 
    wurde aus sachfremden Motiven hinausgeschoben; die Aufarbeitung der Vergangenheit 
    wurde zum Selbstzweck. Damit konnte das Vorgehen des Bundes als des nunmehrigen 
    [REDACTED] der HBInt dazu führen, dass die Kosten für die Allgemeinheit weiter 
    stiegen. 51 
    52 
    53 17 
     C.Zusammenfassung 
    Die Vorkommnisse rund um die HGAA sind von Fehlentwicklungen und Fehlleistungen auf 
    Landes‐ und auf Bundesebene gekennzeichnet. Die rasante Expansion der Bank war nur 
    durch die Landeshaftung möglich, ohne dass das Land Kärnten die damit verbundenen 
    Verpflichtungen hätte erfüllen können. Die verantwortlichen Entscheidungsträger des 
    Bundes unterließen es nach Offenbarwerden der krisenhaften Entwicklung der Bank, die 
    notwendigen  Informationen  angemessen  aufzubereiten,  die  rechtlichen 
    Rahmenbedingungen ausreichend zu prüfen und strategisch vorzugehen, indem 
    Alternativszenarien entwickelt und darauf aufbauend Entscheidungen getroffen wurden. 
    Das begann damit, dass das Land Kärnten die Landeshaftung für die Verbindlichkeiten von 
    HBInt und HBA trotz der Expansion im Ausland aufrecht hielt. Das Land haftete damit für 
    eine Bank, deren Management die [REDACTED]im südosteuropäischen Raum zu 
    nützen versuchte, ohne dass sie über die notwendigen Risikomanagementsysteme und 
    Kontrolleinrichtungen verfügt hätte. Es ist nicht erkennbar, dass Abschlussprüfer, 
    Bankenaufsicht oder das Land Kärnten (die Kärntner Landesholding) die ihnen 
    offenstehenden Möglichkeiten in einem ausreichenden Maß genützt hätten, um auf eine 
    Begrenzung der Risiken hinzuwirken. 
    Das setzte sich mit der Entscheidung des Bundes fort, alle Anteile an der HBInt zu kaufen, 
    ohne Alternativszenarien ausreichend geprüft und in eine Verhandlungsstrategie umgesetzt 
    zu haben. 
    Und es endete – bezogen auf den Untersuchungszeitraum – mit einer fehlenden Strategie 
    für die Zeit nach der Verstaatlichung: Das Beihilfeverfahren wurde nicht mit dem 
    notwendigen Einsatz betrieben; die Entscheidung über eine Bad Bank wurde aus 
    sachfremden Motiven hinausgeschoben; die Aufarbeitung der Vergangenheit wurde zum 
    Selbstzweck. 
    Vor diesem Hintergrund ist dem Land Kärnten anzulasten, mit dem Aufrechterhalten der 
    Landeshaftung eine risikoreiche Expansion im Ausland trotz unzureichender [REDACTED] und 
    Risikomanagement‐Einrichtungen ermöglicht zu haben. Gegenüber dem Bund ist 
    festzuhalten, dass die Verstaatlichung nicht als „Notverstaatlichung“ bezeichnet werden 54 
    55 
    56 
    57 
    5818 
     kann, weil sie – jedenfalls in ihrer Ausgestaltung – keinesfalls alternativlos war. Dem Bund 
    kann auch nicht zugebilligt werden, dass er seine Entscheidungen als Alleineigentümer der 
    HBInt zum Wohle der Bank und der Allgemeinheit getroffen hat. 
    
