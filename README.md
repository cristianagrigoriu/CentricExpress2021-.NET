# CentricExpress2021-.NET
## Unit Tests Setup
In acest pas am facut urmatoarele modificari in proiect:
1. am adaugat proiect nou de teste
2. am adaugat teste pentru FlightDto si FlightsController

### Proiect nou de teste
- click dreapta pe numele solutiei in Solution Explorer -> Add -> New Project
  - tipul de proiect este **NUnit Test Project (.NET Core)**
- in proiectul nou creat, click dreapta pe **Dependencies** -> Add Project Reference si selectam proiectele Flights.Business si Flights.WebApi, pentru ca pe ele le vom testa
- din meniul de sus, selectam Tools -> NuGet Package Manager -> Manage NuGet Packages for Solution si cautam la Browse pachetele **FluentAssertions** (care ne ajuta sa scriem teste intr-un limbaj cat mai apropiat de cel natural) si **Moq** (care ne ajuta sa mock-uim parti din aplicatie pe care nu le testam)

### Teste pentru FlightDto si FlightController
- adaugam in proiect o clasa normala si ii vom da numele entitatii pe care o o testam + *_Tests*, de exemplu *FlightTests* sau *FlightsControllerTests*
- clasa poate contine metode cu urmatoarele atribute:
  -  **[SetUp]**, unde definim pasi ce vor fi urmati *inainte* de fiecare test
  -  **[Test]**, unde definim testul propriu-zis
  -  **[TearDown]**, unde definim pasi ce vor fi urmati *dupa* fiecare test
- fiecare metoda de test contine etapele **Arrange, Act, Assert**; unele din ele pot fi combinate
- pentru a rula testele scrise, putem merge in Test -> Test Explorer, unde le vedem pe toate
  - SAU din clasa de teste, click dreapta -> Run Test(s) sau CTRL R, T

![image](https://user-images.githubusercontent.com/4303957/113333418-14fe0280-932b-11eb-911a-3b0dfc462d3a.png)


#### Structura noului proiect
![image](https://user-images.githubusercontent.com/4303957/113331631-dcf5c000-9328-11eb-8afa-a2a24de73cc1.png)
