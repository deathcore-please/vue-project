<template>
    <div id="app" class="container-fluid">
        <h1>Welcome to the CAME KMS Test App</h1>

        <h3>Objective</h3>

        <p>
            Create a vue new page to display the events stored in the SQLite database in the database folder of the project file.
            There must be the following columns:

            <ul>
                <li>Event Id</li>
                <li>Date Time</li>
                <li>Event Type</li>
                <li>Location</li>
                <li>Fob Code</li>
            </ul>

            The location must display the area the event occoured in, and all of the parent areas above it in the chain. 
            Each area in the areas chain in location must be seperated by a " > " symbol.
            The event type must be displayed as a coloured label with green if access authorised, or red is access is denied for any reason.
            Date time must be displayed in DD/MM/YYYY HH:MM:SS format, and must be sorted with the newest events first. 
        </p>

        <p>
            Any questions: <a href="mailto:ogregory@came.com">ogregory@came.com</a>
        </p>

        <h3>Useful Links</h3>

        <h5 class="mb-0">Vue</h5>
        <p>
            SPA Framework:
            <a href="https://v2.vuejs.org/">Documentation</a>
        </p>

        <h5 class="mb-0">Axios</h5>
        <p>
            HTTP Client:
            <a href="https://github.com/imcvampire/vue-axios">Vue Integration Documentation</a>
            -
            <a href="https://axios-http.com/docs/intro">Documentation</a>
        </p>

        <h5 class="mb-0">Bootstrap</h5>
        <p>
            CSS / Component Framework:
            <a href="https://getbootstrap.com/docs/4.6/getting-started/introduction/">Documentation</a>
        </p>

        <h5 class="mb-0">Bootstrap Vue</h5>
        <p>
            Vue Component Framework:
            <a href="https://bootstrap-vue.org/docs">Documentation</a>
        </p>

        <h5 class="mb-0">.NET SQLite</h5>
        <p>
            SQLite .NET Connector
            <a href="https://github.com/praeclarum/sqlite-net/wiki">Documentation</a>
        </p>

    </div>
</template>

<script>
    
    export default {
      components: {
      },

      data () {
        return {}
      }
    }
</script>

<style>
</style>
