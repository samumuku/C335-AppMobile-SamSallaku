# Samuel Sallaku C335 APP MOBILE

# 21.03.2025

## Identification du module

## Cahier des Charges

## Présentation 1

### Différence entre app normale et mobile

- Formattage
- Ressources à gérer, entre différents appareils / versions / tailles, etc
- On dev sur un environnement, pour l'utiliser sur un autre
- Donc lancer l app pour du débogage ne marchera pas
- Fonctionne avec ou pas internet
- Mettre à disposition l'application avec des magasins comme Google play ou App store
- UX

### Technologies

- Web (webassembly)
- Natif spécifique (code doit être plutôt unique)
  - Android (java)
  - iOS (objective-c, swift)
- Natif lié
  - Kivy (python)
  - Kotlin
- Natif avec runtime (code partagé entre différentes platformes et environnements)
  - .NET MAUI (mono)
  - React (Javascript)
  - Flutter

### Installations

- Ajouter le composant d'app mobile s'il n'existe pas déjà, "Développement .NET Multi-Platform App UI"
- dézip le dossier "etml-android-emulator" , puis lancer le .bat
- Ajouter l'émulateur Android sur Visual Studio
- Accepter la license
- Puis normalement l'émulateur sera éxécutable sur Visual Studio, le bouton éxécuter
- Et donc attendre

### Activer mode dév sur le mobile

1. Connecter l'appareil au PC
2. Ouvrir les paramètres sur le mobile
3. Aller sur "A propos du téléphone"
4. Ensuite sur "Informations sur le logiciel"
5. Trouver "Numéro de version", puis taper 7 fois de suite dessus.
6. Un message disant que le Mode dév a été activé devrait être visible.
7. Puis une option "Options de développement" va aussi apparaître

### Fichiers créés

- Xaml = vue
- Xaml.cs = Code
- MauiProgram.cs = Equivalent au Program.cs dans un projet normal
- App.xaml.cs/App.xaml = Fichiers avec un langage avec des balises, comme HTML. Cela sera la partie graphique.
- AppShell = contient la navigation prépréparée
- Page Standard = MainPage.xaml

### XAML

    Volé par Microsoft, et a ajouté des balises. Il a été créé pour justement ces applications mobiles

    Balises comme en HTML

    Hiérarchie(comme des poupées russes)

- E**X**tensible
- **A**pplication
- **Markup**
- **Language**

```
Afficher un bouton ====== <Button Text="quitter"/>
Une grille ====== <Grid WidthRequest ="100" HeightRequest="100">
<BoxView1, etc
```

## Questions

1. Que veut dire l'acronyme MAUI - Multi-platform Application User Interface
2. Comment ce fait-il que C# fonctionne sur Android - Runtime qui transforme la machine en android (compilation)
3. Comment tester une application MAUI Android développée sur Windows alors que nous n'avons pas d'appareil mobile ? - Emulateur
4. Citez 3 alternatives MAUI pour le développement mobile - Natif spécifique, Natif liée, Web React, Kotlin, WebAssembly, etc

# 28.03.2025

- Revue de ce qui a été fait la semaine passée
- Maquettes pour projet

## Présentation 2

#### Shell

##### 4 types de navigation

- Content page
- Flyout Page ( page qui apparait lors d un clic ou swipe )
- Navigation Page ( navigation normale, comme par exemple les boutons )
- Tabbed Page ( Menu tout en bas (footer) )

##### 2 types d'app

- App => AppShell => Main

- Basique

  - Pas de menu de navigation intégrée
  - Code de base : (InitializeComponent(), MainPage = new NavigationPage (new MainPage()))

- Shell (par défaut pour une nouvelle app)
  - Menu initial Flyout **OU** tab

##### Navigation

- 1er niveau (root)

  - Shell => défini par Flyout ou Tab, puis un NavigationPage
  - Basique => défini directement par NavigationPage

- 2ème niveau et N ème niveau (détail)
  - Stacker les pages

PUSH/POP = PUSH sert à aller dans une autre page, et POP sert à revenir

- Certaines navigations ne fonctionnent pas ensemble

##### Layout (XAML)

Mise en page

- Tailles différentes

- 4 Layouts
  - StackLayout (mettre les éléments empilés)
  - AbsoluteLayout (Valeurs absolues, il fat définir dans quels pixels il sera placé)
  - Grid (Une grille, définir le nombre d'éléments)
  - FlexLayout (Permet de définir les colonnes et les lignes comme avec Flexbox CSS, permet aussi de stacker les différents Layouts et les mélanger)

On peut choisir et il va normalement régler la taille par lui même

## Questions

- Citez le type d'application qui permet d'avoir les 2 options de navigation principales, citez les deux options et illustrez leur rendu.
  - Tabulation et Flyout
  - Type d'application: Shell
- Avec un navigation standard, sans AppShell, comment naviguer entre les pages?
  - Content Page/Navigation Page
  - Push et Pop
- Citez les 4 Layout de base et décrire leur comportement de base.
  - Grid=(fait une grille et met les éléments dedans)
  - Flex=(responsive)
  - Stack=(empiler les éléments, horizontalement ou verticalement)
  - Absolute=(Fixé à une position exacte, le point en haut à gauche de l'élément)

# 04.04.2025

- Revue de ce qu'on a fait la semaine passée
- Continuer sur l'exercice de Crane
- Continuer sur figma
- Débuter avec une navigation

## Présentation 3

#### Interactions User

- Code Behind -> code de base lors de la création
- Razor
- MVVM (Model View ViewModel)
  - Model = C# (Informations, Services, Base de données)
  - View = Composants graphiques
  - ViewModel = Pilote de l'application, C#

##### Exercice

- Appeler le nom de la variable + Command, en utilisant "Binding"
- Ajouter un bouton et un label:

```
<Entry Text="0"/>
<Button Text="Counter : 0 [click to inc 5]" />
```

## Questions

-
-
-
-

# 11.04.2025

- Revue de ce qu'on a fait la semaine passée
- Continuer sur exercice 2 de MVVM
- Faire l'exercice 3 de MVVM
- Pour le débogage, il faut un (Trace.WriteLine($"Texte {variable}.. "))
