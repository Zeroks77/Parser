# Eigener Parser mit der Hilfe von [Sprache](https://github.com/sprache/sprache)
Hier habe ich einen Parser geschrieben, der aus einer .csv Datei Dota2 
Helden, Rollen und ihr Lanes 'herraussucht' und in ein Heldenmodel schreibt.
Im Anschluss wird eine Liste von diesen Model ausgegeben.

## In Wie Weit ist Sprache Anwendbar
Da das meine erste Erfahrung mit Linq und wie man einen Parser schreibt war, möchte ich keine Angst verbreiten.
Hat man das System hinter Sprache verstanden, dann schreibt sich der Parser fast wie von selbst :D <br>
Auch wenn der Einstieg nicht gerade einfach war, nach einem Tag nur Beispielcode ([den](https://nblumhardt.com/2010/01/building-an-external-dsl-in-c/) , [den](https://github.com/OctopusDeploy/Octostache/blob/master/source/Octostache/Templates/TemplateParser.cs), [den](https://www.ianwold.com/blog/2016/1/22/an-introduction-to-sprache) und [den](https://github.com/sprache.Tests/Scenarios/CsvTests.cs)) lesen, hatte ich es dann verstanden. <br>

Die Grundlegende Syntax für Sprache ist sehr an Linq angelegt und damit auch einfach anzuwenden. Das einzige was man dann noch benötigt ist eine Voprstellung, von dem was man machen möchte und wie man es in SQL/ Linq umsetzten kann.

Sprache bietet eine große Bibliothek an kleinen Helfern. So zum Beispiel die Except, Many und Text Methoden.
```csharp
public static readonly Parser<string> input =
            (from content in Parse.AnyChar.Except(splitHere).Many().Text().Named("Heroname") //Heldenname
             select content).Token();
```
Diese Methoden, machen im Grunde genau das, was ihr Name schon verrät. Mit der ```Except()``` Methode sagt man, dass man so lange Parsen möchte bis ein bestimmter Character auftaucht. Die ```Many()``` Methode sagt dem Parser, dass viele Character geparsed werden und schlussendlich wandelt die ```Text()``` Methode die geparsten Characters zu einen String um.



Danke das du mich gelesen hast. Ich wünsche dir einen schönen Tag und viel Spaß beim experimentieren mit [Sprache](https://github.com/sprache/sprache)
