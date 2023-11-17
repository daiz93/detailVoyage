# DetailVoyage
Une application qui permet aux utilisateurs de voir les détails de leur voyage à venir, en utilisant une API GraphQL comme intermédiaire pour plusieurs API REST.


## Technologies Utilisées
- **Langages de Programmation:** ASP .NET CORE, Graphql, JS
- **Frameworks:** Entityfromaworkcore 7
- **Outils:** HotChocolate

## Architecture

Nous avons souhaité que les différentes APIs puissent être dévéloppés par des équipe différentes et puissent évoluer indé
**Trois APIs REST, en .NET CORE**
Client API : Gere les données client

DossierAPI: Gère les dossiers de voyage

ProduitAPI: Gère les Porduits, dans le cas d'espèce des hotèls

**Un projet Core**
Il contient les entités et est une dépendance pour les autres projets

**Une API Graphql**

Basé sur les résolveur elle sert d'intermédiaire entre le bakend et le frontend

**Une Application React**
Il s'agit du frontend, la partie visible pour les utilisateurs.

## Installation

'''Commande doker à renseigner'''
## Configuration
 

## Utilisation


## Auteur
Desmond KPOHIZOUN





