# ElectronDepot

## Idea projektu:
Masz w domu dużo układów scalonych i nawet nie wiesz co masz na stanie a co powinieneś kupić. Na przykład ja ostatnio przeglądałem szafe i znalazłem jakieś IC nawet nie wiem skąd się wzieły. Co z tym zrobić? Rozwiązaniem jest ElectronDepot. Jest to aplikacja składająca się z servera oraz clienta.
# Server
- Zawiera baze danych zebranych przez ten czas układów scalonych.
- Układy scalone przechowywane dla konkretnego użytkownika.
- Udostępnia RestAPI umożliwiając pobranie zawartych danych z bd.
- Umożliwia ściąganie danych na temat zakupionych części na bierząco (np. poprzez skanowanie emaili z powiadomieniem o przesyłce. Może obsługiwać powiadomienia z takich sklepów jak Allegro, Botland, Kamami, MSalamon czy AliExpress)
- Umożliwia przechowywanie informacji na temat gdzie zastosowane zostały dane części (nazwa projektu i jakie części)

# Client
- Aplikacja desktopowa/webowa pozwalająca na interakcję z serverem.
- Filtrowanie/sortowanie/przeszukiwanie urządzeń które są dostępne
- Dodawnie nowych urządzeń oraz modyfikowanie wykorzystania istniejących.
- Tworzenie projektów i przypisywanie wykorzystania modułów.
- Konfiguracja serwisów które będą śledzone do otrzymywania automatycznego dodawnia do bazy danych.
- Logowanie na danego użytkownika.

---
# Architektura
# Server
- RestAPI napisane za pomocą ASP.NET Core.
- Skrypt do web-scrapowania w C#.
## Client
- Desktopowa aplikacja napisana w C#/WPF.