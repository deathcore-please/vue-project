<template>
    <ul class="navbar-nav mr-auto">
        <li class="nav-item">
            <router-link to="/" class="nav-link">Home </router-link>
        </li>

        <li class="nav-item">
            <router-link to="/events" class="nav-link"> Events </router-link>
        </li>
        <li class="nav-item">
            <router-link to="/weather" class="nav-link"> Weather </router-link>
        </li>

        <!--<li class="nav-item dropdown">
        <a class="nav-link dropdown-toggle" href="#" id="navbarTicketsDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
            Tickets
        </a>
        <div class="dropdown-menu" aria-labelledby="navbarTicketsDropdown">
            <router-link to="/tickets" class="dropdown-item"> Tickets </router-link>
            <router-link to="/ticket-create" class="dropdown-item"> Add Ticket </router-link>
        </div>
    </li>-->


    </ul>
</template>

<script>

  export default {
    data() {
      return {
        collapsed: false
      }
    },
    methods: {
    },
    created() {
      
    }
  }
</script>

<style>
  .slide-enter-active, .slide-leave-active {
    transition: max-height .35s
  }

  .slide-enter, .slide-leave-to {
    max-height: 0px;
  }

  .slide-enter-to, .slide-leave {
    max-height: 20em;
  }
</style>
