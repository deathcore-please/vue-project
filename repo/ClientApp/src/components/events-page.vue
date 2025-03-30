<template>
  <div class="container mt-4">
    <h2>CAME CMS Events</h2>
    <p>Welcome to the Events page! This component demonstrates the CAME KMS events.</p>
    <h6>Built by Shvetanshu Raps Gumma</h6>
    <table class="table table-striped">
      <thead>
        <tr>
          <th>Event Id</th>
          <th>Date Time</th>
          <th>Event Type</th>
          <th>Location</th>
          <th>Fob Code</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="event in events" :key="event.eventId">
          <td>{{ event.eventId }}</td>
          <td>{{ formatDate(event.dateTime) }}</td>
          <td>
            <span :class="['badge', event.type.includes('Authorised') ? 'bg-success' : 'bg-danger']">
              {{ event.type }}
            </span>
          </td>
          <td>{{ event.location }}</td>
          <td>{{ event.fobCode }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'EventsPage',
  data() {
    return {
      events: []
    };
  },
  methods: {
    async fetchEvents() {
    try {
      console.log("Fetching events...");
      const baseUrl = process.env.VUE_APP_API_URL || 'http://localhost:5000';
      const response = await axios.get(`${baseUrl}/api/events`);
      console.log("Response data:", response.data);
      if (Array.isArray(response.data)) {
        this.events = response.data;
        console.log("Events successfully loaded:", this.events);
      } else {
        console.warn("Data received is not an array");
      }
    } catch (error) {
      console.error('Error fetching events:', error.message);
    }
  },
    formatDate(dateTime) {
      const date = new Date(dateTime);
      return date.toLocaleString('en-GB', {
        day: '2-digit', month: '2-digit', year: 'numeric',
        hour: '2-digit', minute: '2-digit', second: '2-digit'
      });
    }
  },
  mounted() {
    console.log("EventsPage component has been mounted");
    this.fetchEvents();
  }
};
</script>

<style>
.badge {
  padding: 0.5em;
  border-radius: 0.25em;
  color: white;
}
.bg-success {
  background-color: green;
}
.bg-danger {
  background-color: red;
}
</style>
