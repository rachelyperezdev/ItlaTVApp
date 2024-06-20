# ItlaTVApp, Series Management System - ASP.NET Core MVC

## Overview

This project is an ASP.NET Core MVC application designed to manage TV series, producers, and genres. Users can view, create, update, and delete series, producers, and genres. The system provides filtering and search functionalities to easily navigate through the series based on various criteria.

## Glossary

* Series → Series
* Genero → Genre
* Productora → Producer

## General Features

### Home

The home screen includes a menu with the following options:

* Home
* Series (Manage Series)
* Productoras (Manage Producers)
* Géneros (Manage Genres)

#### Home screen details

* Displays a list of all series with:
  * Series name
  * Cover image
  * Associated genres
  * Associated producer
  * A button to view series details
 
* Series detail screen includes:
  * Title of the series
  * Video player for a YouTube video link of the series
 
#### Filters and search

* Search by series name
* Filter by producer
* Filter by genre

### Management sections

The application allows users to manage Series, Producers, and Genres. Below are the common actions for managing these entities.

#### Listing Entities

* Each management section displays a list of all entities with relevant details.
* Each entity in the list has buttons for editing and deleting.
* A button at the top of the list allows for the creation of a new entity.

#### Creating an Entity

Clicking the create button navigates to a form for adding a new entity.

* Series form fields:
  * Series Name (required)
  * Cover Image URL (required)
  * YouTube Video URL (required)
  * Productora (required, dropdown list)
  * Primary Genre (required, dropdown list)
  * Secondary Genre (dropdown list)
 
* Producer Form Fields:
  * Producer Name (required)

* Genre Form Fields:
  * Genre Name (required)
 
Forms includes validation for required fields.

#### Editing an Entity

* Clicking the edit button navigates to a pre-filled form for updating the entity.
* The form fields are similar to the creation form with existing values pre-filled.
* Validation are the same as the creation form.

#### Deleting an Entity

* Clicking the delete button navigates to a confirmation screen.
* Two buttons: one to cancel and return to the list, and one to confirm the deletion.

## Specific Management Sections

### Series Management
* Accessed via the "Series" option in the main menu.
* Lists all series with:
  * Series name
  * Cover image
  * Associated genres
  * Associated producer
    
### Producer Management
  * Accessed via the "Productoras" option in the main menu.
  * Lists all producers with:
    * Producer name
### Genre Management
  * Accessed via the "Géneros" option in the main menu.
  * Lists all genres with:
    * Genre name
    
## Getting started

### Prerequisites 

* [.Net Core SDK](https://dotnet.microsoft.com/en-us/download)
* [Visual Studio](https://visualstudio.microsoft.com/) or any preferred IDE for ASP.NET Core development
