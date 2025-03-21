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
