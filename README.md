# Game Of Life 
C# WPF avec .NET Core

# Introduction

## Contexte
Ce projet entre dans le cadre du cours de .NET de la He-Arc. Il s'agit d'un jeu de la vie de Conway développé en C# avec WPF. 

## Developpeurs
* Luca Laissue
* Robin Danz
# Les automates cellulaires

Un automate cellulaire est une grille (un tableau) régulière comportant des cellules. Chaques cellules est définit par un état (mort et vivant par exemple). L'état des cellules de la grille évolues en fonction du temps. L'état au temps t+1 d'une cellule est calculé en fonction de l'état au temps t d'un certain nombre de cellules qui définissent son voisinage. A chaque incrémentation du temps, des règles sont appliquées simultanément aux cellules de la grille qui produise une nouvelle génération de cellules qui dépend entièrement de la génération précédente.

# le jeu de la vie de Conway

Il s'agit d'un automate cellulaire imaginé par John Conway en 1970. Les cellules qui composent la grille de l'automate possèdent deux états : morte ou vivante.

## Les règles d'évolution

A chaque itérations, l'évolution d'une cellule est déterminée par l'état de ces 8 cellules voisines en suivant les règles suivantes:

 - Une cellule morte possédent exactement trois voisines vivantes devient vivante (naissance d'une cellule)

 - Une cellule vivante possédant deux ou trois voisines vivantes le reste, sinon elle meurt
# Rappel du cahier des charges
## Maquette
Voici une maquette élaboré au début du projet. La fenêtre de jeu est différente dans l'état actuel du programme.
![maquette_projet_finish](https://user-images.githubusercontent.com/43986199/100355723-8c74fb80-2ff2-11eb-9b54-b64688904b97.PNG)

## Objectifs
Les objectifs suivants ont étés fixés au début du projet
### Principaux
- Implémentation du [jeu de la vie de Conway](https://fr.wikipedia.org/wiki/Jeu_de_la_vie) en WPF 
- Choix de la taille de la grille
- Choix de la configuration de départ en cliquant sur les cases
- Possibilité de pause/play l'automate
- Possibilité de modifier l'état de la grille pendant la pause

### Secondaires
- Importation/exportation d'une grille 
- Bibliothèque de pattern p.ex:
    - Clown
    - Jardin d'Eden
    - Canon à planeurs
    - Etc, selon le temps

# Schéma de classe
![WPFConway](https://user-images.githubusercontent.com/43986199/104861130-d4e3d200-592e-11eb-8955-bef04d493146.jpg)

## Détail

 - GameGrid : contient une représentation booléenne de la grille de jeu. C'est cette classe qui implémente les règles de l'automate cellulaire et gère l'état des cellules à chaque tour de jeu.
 - Cell : les cellules de la grille de jeu. Etend la classe de base C# Button
 - Patterns : contient des méthodes pour créer les patterns
 - GameWindow : fenêtre de jeu
 - MainWindow : fenêtre de lancement du jeu

# Développement

Le développement du projet s'est passé principalement en pair-programming. Le contenu étant relativement petit cette méthode permettait de développer du code tout en faisant directement des reviews.

# Principe de fonctionnement 

Pour cet automate cellulaire C# il a été décidé d'utiliser une Grid remplit de bouton cliquables. Les boutons représentent les cellules de l'automate et sont colorés selon leurs états, blanc s'ils sont mort et noir s'ils sont vivant. La grille est représenté par un tableau de booléen dans le code et c'est sur cette grille que l'algorithme applique les règles à chaques itérations.

# Performances

Comme le résultat final de la grille de bouton ne donnait pas entière satisfaction en terme de performances lors du redimensionnement de la fenêtre, d'autres solutions ont étés envisagées. L'une de ces solutions était de remplacer la grille de bouton par un canvas contenant des rectangles représentants une grille. Cette solution à été mise en place mais quand est venu le moment de tester ce fut la désillusion : les performances étaient catastrophique. Il y avait un délai de presque une seconde lorsque qu'une case était cliqué et l'automate avançait très péniblement. Finalement, le choix a été fais de revenir à la première version : la grille de bouton. 

Finalement, cette grille de bouton offre des performances acceptables pour un automate cellulaire. Le jeu tourne bien et l'évolution se fait de manière fluide. Le seul bémole, comme précisé plus haut, est le redimensionnement de la fenêtre qui créée quelques lags. 

# Fonctionnalités

Ce jeu de la vie permet à l'utilisateur d'effectuer les actions suivantes:
 - Selection des cellules de départ
 - Choix d'un pattern pour la séléction. Il existe 4 pattern actuellement: 
    - La cellule basique (par défaut)
    - Une ligne de 3 cellules
    - Un planeur
    - Une croix de 7 cellules d'envergures
    - Une "étoile" 
 - Possibilité de mettre le jeu en marche/pause à tout moment
 - Possibilité de remettre la grille à 0
 - Possibilité de lancer plusieurs fenêtre de simulation simultanément
 - Compteur d'itérations
 - Choix de la taille de la grille dans une liste prédéfinis

# Conclusion

Malgré le contexte actuel, nous sommes parvenus à atteindre tous nos objectifs principaux.
Le projet pourrait sans doutes être amélioré en utilisant une méthode plus performante pour l'affiche de la grille mais après avoir essayé avec un canvas il semblerait que nous faisions fasse à une limitation de WPF.

# Sources
https://fr.wikipedia.org/wiki/Automate_cellulaire

https://fr.wikipedia.org/wiki/Jeu_de_la_vie


