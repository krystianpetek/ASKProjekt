# Projekt symulacji operacji Intel 8086
Projekt realizuje zadanie symulacji wykonywania operacji mikrokontrolera Intel 8086.
Intel 8086 był to 16 bitowy mikroprocesor. Jego zastosowanie, doprowadziło do jego wielkiej popularyzacji tej rodziny procesorów.

### Prezentacja
1. Przypisanie wartości do rejestru lub wylosowanie wartości z zakresu 0000 - FFFF (65535), gdyż procesor działa w architekturze 16 bit. 
2. Po przypisaniu wartości do pól tekstowych kliknij przycisk PRZYPISZ aby przypisać wartości do rejestru. 
W przypadku losowania wartości przejdź do punktu 3.
3. Masz możliwość przenieść wartości z rejestru np. AX do BX, CX, lub DX lub przemiennie lub zamienić wartości w rejestrach
4. Przypisz wartości do rejestru indeksowego SI, bazowego BP i / lub przemieszczenia DISP.
5. Następnie wybierz z którego rejestru przenieść wartość do pamięci.
Przykładowo z rejestru DX o wskaźniku indeksowo-bazowego [SI + BP] + DISP przenieś wartości z rejestru DX do pamięci, lub odwrotnie.
6. Można także przenieść wartości z rejestrów np. BX lub DX na stos i pobrać ze stosu.

Program możliwia także zresetowanie całej symulacji i posiada także podgląd stanu wykonywania czynności: 
* Podgląd rejestru operacji symulatora 
* Podgląd wartości w pamięci
* Podgląd wartości na stosie

Autor: Krystian Petek
Projekt zrealizowałem na ocenę 5.

Był to mój pierwszy projekt, podczas nauki języka C#, zrealizowany w technologii WinForms.
Tworzony był na zaliczenie przedmiotu Architektura systemów komputerowych na studiach informatycznych.