1. Que veut dire l'acronyme MAUI

   - Multi-platform Application User Interface

2. Comment ce fait-il que C# fonctionne sur Android
   - Runtime qui transforme la machine en android (compilation)
3. Comment tester une application MAUI Android développée sur Windows alors que nous n'avons pas d'appareil mobile ?
   - Emulateur
4. Citez 3 alternatives MAUI pour le développement mobile

   - Natif spécifique, Natif liée, Web React, Kotlin, WebAssembly, etc

5. Citez le type d'application qui permet d'avoir les 2 options de navigation principales, citez les deux options et illustrez leur rendu.
   - Tabulation et Flyout
   - Type d'application: Shell
6. Avec un navigation standard, sans AppShell, comment naviguer entre les pages?
   - Content Page/Navigation Page
   - Push et Pop
7. Citez les 4 Layout de base et décrire leur comportement de base.

   - Grid=(fait une grille et met les éléments dedans)
   - Flex=(responsive)
   - Stack=(empiler les éléments, horizontalement ou verticalement)
   - Absolute=(Fixé à une position exacte, le point en haut à gauche de l'élément)

8. Que veut dire MVVM ?
   - Model View ViewModel => manière de coder. Model: occupe la DB et récupérer les données, View: Partie visuelle ou bien Frontend. ViewModel: lien entre le backend et frontend
9. A quoi sert la notation [RelayCommand] ET d'où cela vient ?

   - Elle sert à relier une méthode avec le View, comme le ObservableProperty relie les variables

10. Comment faire en sorte qu'un label affiche dynamiquement la valeur d'un attribut int

    - en utilisant un Binding dans la propriete Text, et dans le ViewModel en utilisant ObservableProperty

11. Citer une alternative à MVVM ?

    - Code Behind, React, Blazer

12. Comment faire pour que le contenu d'une liste soit sauvegardé après le démararage de l'application
    - associer les données à un système de gestion de données comme une DB, Sqlite
13. A quelle frequence les données de l'accéléromètre sont transmisses à l'application ?
    - ca dépend de ce qu'on mets, cela peut être soit Default=200, soit UI=60, Game=20 ou bien Fastest=5
14. L'accéléromètre permet de détecter les mouvements sur quels axes?
    - X.Y.Z
15. En quoi les capteurs peuvent impacter particulièrement négativement le téléphone
    - L'utilisation des ressources, et surtout la batterie
