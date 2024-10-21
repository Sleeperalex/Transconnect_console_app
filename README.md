### 1. Contexte du sujet et Objectif

**TransConnect** est une entreprise de transport routier qui connaît une période de croissance nécessitant l'agrandissement de son personnel et de ses opérations. Face à ces besoins, un système de gestion informatique en C# a été envisagé pour faciliter et optimiser la gestion des salariés, des clients, et des commandes.

L'objectif principal du projet est de développer une application C# permettant au directeur, M. Dupond, de visualiser efficacement l'organigramme de l'entreprise, de gérer les ressources humaines, de suivre les commandes en temps réel, et de maintenir une base de données clientèle active et informative.

---

### 2. Les différents modules

#### Module Client
- **Gestion des clients** : Ajout, suppression, et modification des clients.
- **Affichage des clients** : Tri par ordre alphabétique, par ville, ou par montant des achats cumulés.

#### Module Salarié
- **Visualisation de l'organigramme** : Utilisation d'un arbre n-aire pour une représentation claire.
- **Gestion des salariés** : Embauche et licenciement avec mise à jour de l'organigramme.

#### Module Commande
- **Gestion des commandes** : Création et modification des commandes avec enregistrement des données pour enrichir progressivement la base.
- **Optimisation des trajets** : Utilisation de l'algorithme de Dijkstra pour déterminer les itinéraires les plus courts et affectation des chauffeurs disponibles. 
<div style="page-break-after: always;"></div> 
### Attention
- Certains chemins ne sont pas possible car nous avons construit un graphe orienté sur les villes, (ce qui n'est pas très logique pour des villes mais nous avons suivi l'exemple du cours).
#### Module Statistiques
- **Suivi des performances** : Calcul et affichage des statistiques telles que le nombre de livraisons par chauffeur, la moyenne des prix des commandes, et l'historique des commandes par client.

#### Module Autre
- **Module Vehicule** : Ajouter un véhicule, Retirer un véhicule, Afficher les véhicules libre et/ou non libre, Rechercher un véhicule par ID.
- **Menu Dijkstra** : Menu on l'on peut mettre une ville de depart et d'arrivée et ressort le plus court chemin en temps ou distance.
- **Methode Remplacer dans la classe entreprise** : remplace le poste de 2 salaries dans l'entreprise.

### 3. Structure de l'Application TransConnect

Le projet TransConnect est organisé en plusieurs modules, chacun contenant des classes spécifiques conçues pour gérer différents aspects de l'entreprise de transport. Voici une description détaillée des dossiers et des classes qu'ils contiennent, reflétant la structure organisée du système.

#### Dossier `PersonneModel`

Ce dossier regroupe les classes qui définissent les personnes associées à l'entreprise, qu'il s'agisse de clients ou de salariés.

- **`Adresse.cs`** : Gère les détails d'adresse pour les personnes, utilisée dans les profils des clients et des salariés.
- **`Chauffeur.cs`** : Spécialisation de la classe `Salarie`, gère les chauffeurs, incluant leur disponibilité pour les livraisons.
- **`Client.cs`** : Dérivée de `Personne`, cette classe gère les interactions avec les clients, incluant les commandes qu'ils placent.
- **`Personne.cs`** : Classe de base pour tous les individus, contenant des informations générales telles que nom, adresse, et contact.
- **`Salarie.cs`** : Dérive de `Personne` et ajoute des informations spécifiques aux employés, telles que le numéro de sécurité sociale et les détails du poste.

#### Dossier `VehiculeModel`

Ce dossier inclut toutes les classes relatives aux différents types de véhicules utilisés pour le transport de marchandises.

- **`Camion.cs`, `CamionBenne.cs`, `CamionCiterne.cs`, `CamionFrigorifique.cs`** : Différents types de camions pour divers usages spécifiques (transport de liquides, matériaux de construction, produits périssables, etc.).
- **`Camionnette.cs`** : Véhicules plus petits pour des livraisons rapides ou en milieu urbain.
- **`Vehicule.cs`** : Classe de base pour tous les véhicules, contenant des attributs et méthodes communs.
- **`Voiture.cs`** : Véhicules destinés au transport de passagers.

#### Dossier `ArbreModel`

Gère la structure hiérarchique de l'entreprise à l'aide de structures de données arborescentes.

- **`Arbre.cs`** : Classe qui implémente l'arbre n-aire pour représenter l'organigramme de l'entreprise.
- **`Noeud.cs`** : Représente un noeud dans l'arbre, pouvant contenir une référence à un `Salarie`, un `Chauffeur`, ou toute autre personne.

#### Dossier `DijkstraModel`

Contient les classes pour l'implémentation de l'algorithme de Dijkstra, utilisé pour calculer les itinéraires les plus courts.

- **`Arc.cs`** : Représente un segment entre deux noeuds dans le graphe des itinéraires.
- **`Graphe.cs`** : Gère un ensemble d'arcs et de noeuds pour l'application de l'algorithme de Dijkstra.

#### Dossier `CommandeModel`

Focalisé sur la gestion des commandes et des produits.

- **`Commande.cs`** : Classe qui gère les détails d'une commande, y compris le client, le chauffeur, le véhicule utilisé, et le trajet.
- **`Produit.cs`** : Décrit les produits inclus dans les commandes, avec des informations sur le prix, la quantité, et les spécifications.

#### Dossier `EntrepriseModel`

Concentré sur la gestion globale de l'entreprise.

- **`Entreprise.cs`** : Classe centrale qui coordonne les opérations entre les salariés, les véhicules, les clients, et les commandes.
- **`Statistiques.cs`** : Fournit des analyses et des rapports sur divers aspects de l'entreprise, comme la performance des chauffeurs et la fréquence des commandes.
