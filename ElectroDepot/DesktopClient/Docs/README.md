# Latest TODO:
 - Trzeba sie dowiedzieć jak zaimplementować customowe komendy do customowych elementów takich jak te na stronie "Home Page"
# UI
![BasicUI](Images/BasicUI.gif)

# Toturial - Jak dodawć nowe customowe elementy oparte na innych
Jak chcesz zrobić jakiś nowy element UI, i chciałbyś żeby dziedziczył po czymś żeby zachować jakieś konkretne własności możesz postąpić tak.
Przykład:
 - Stwórz nowy TemplateControl i w klasie zmien dziedziczenie na takie jakie chcesz np. Button
 - W pliku .axml aby połączyć się z własnościami tej klasy po której dziedziczysz użyj: Command="TemplateBinding Command"
 - Wszystko co wsadzisz ControlTemplate będzie wyświetlane na ekranie.
 - Aby wykorzystać prawidłowo Command to w .axml musi być coś co to ztriggeruje. Nie wiem czy nie ma czegoś takiego dla pozostałych elementów.

# TODO - Desktop client
- [ ] Home view:
	- [ ] Animations
	- [ ] Graph
	- [ ] Add new items shortcuts
- [ ] ...
- [ ] ...