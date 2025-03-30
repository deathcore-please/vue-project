import EventsPage from '../components/events-page.vue';

export default [
  {
    path: '/',
    name: 'home',
    component: () => import('../components/welcome-page.vue')
  },
  {
    path: '/events',
    name: 'events',
    component: EventsPage
  },
  {
    path: '/weather',
    name: 'weather',
    component: () => import('../components/weather-page.vue')
  }
];