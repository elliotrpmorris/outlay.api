# Outlay.API

## Setup

To get the Outlay.API service up and running locally on your machine, just follow this step by step guide.

### Requirements

* Docker - You will need Docker desktop installed and running. Docker desktop can be downloaded from the following pages:

  https://hub.docker.com/editions/community/docker-ce-desktop-windows/
* Insomia - You will need a tool to query the graphql API Insomia is great for this!

  https://insomnia.rest/download/core

### Steps

1. From a terminal, navigate to the Outlay.API folder, once there run:
    ```
    docker-compose up
    ```

    This will run postgres and pgadmin.

2. In a browser, navigate to the localhost:7070 to open pgAdmin, now login using the credentials specified in the docker-compose file. In this case it should be the following:

    ```
    Email: `hello@hello.com`

    Password: `password`
    ```

3. Now that you're in, you will need to create a server, near the top left of the window you should see something that says Servers, right click on this and follow Create -> Server, this will open a modal where you will configure the server.

4. First name your server, in the General tab of the modal, fill in the Name field, this can be anything you want. Next go to the Connection tab and update the following fields:

    ```
    Host name/address: host.docker.internal
    
    Port: 5432

    Username: postgres
    
    Password: password
    ```

    The Username & Password are set to what was specified in the `appsettings.json` file.

    Once this is done, press save.

5. Now run the API project and when you send your first query the DB will auto create and seed with some data.

## Testing the application

1. Open insomnia at the top left click `Application` then `Preferences` then click the `Data` tab. 

2. Click `Import data` then `from file` navigate to the root folder of `outlay.api` and select the `Insomnia_Requests.json`

3. This will populate your envrioment with all availble commands and a some example GraphQL requests. 


### Querying the API 
 (Please note this example will be using Insomia but you can also query this using other tools for example Postman is a popular API client)
 
 1. Open Insomnia. Click the plus and New Request this can be called anything. But make sure the type is `POST`
 
 2. On the Body drop down then click GraphQL Query. 
 
 3. For the url enter `http://localhost:5000/query`
 