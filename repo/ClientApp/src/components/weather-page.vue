<template>
    <div class="container-fluid">
        <h1>Weather forecast</h1>

        <p>This component demonstrates fetching data from the server.</p>

        <b-table striped hover :items="forecasts" :busy="loading" :fields="fields">

            <template #cell(date)="data">
                {{ data.value | date }}
            </template>

            <template #cell(temperatureC)="data">
                <b-badge :variant="getColor(data.value)">{{ data.value }}</b-badge>
            </template>

        </b-table>

        <b-alert :show="showError" variant="danger">
            {{ errorMessage }}
        </b-alert>

        <b-alert :show="showError" variant="warning">
            Are you sure you're using ASP.NET Core endpoint? (default at
            <a href="http://localhost:5000/fetch-data">http://localhost:5000</a>)
            <br />
            API call would fail with status code 404 when calling from Vue app (default at
            <a href="http://localhost:8080/fetch-data">http://localhost:8080</a>) without devServer proxy
            settings in vue.config.js file.
        </b-alert>

    </div>
</template>

<script>

    export default {
        data() {
            return {
                loading: true,
                showError: false,
                errorMessage: 'Error while loading weather forecast.',
                forecasts: [],
                fields: [
                    { label: 'Date', key: 'date' },
                    { label: 'Temp. (C)', key: 'temperatureC' },
                    { label: 'Temp. (F)', key: 'temperatureF' },
                    { label: 'Summary', key: 'summary' }
                ]
            }
        },
        methods: {
            getColor(temperatureString) {
                var temperature = parseInt(temperatureString);
                if (temperature < 0) {
                    return 'info'
                } else if (temperature >= 0 && temperature < 30) {
                    return 'success'
                } else {
                    return 'danger'
                }
            },
            async fetchWeatherForecasts() {
                try {
                    const baseUrl = process.env.VUE_APP_API_URL || 'http://localhost:5000';
                    const response = await this.$http.get(`${baseUrl}/api/WeatherForecast`);
                    this.forecasts = response.data;
                } catch (e) {
                    this.showError = true;
                    this.errorMessage = `Error while loading weather forecast: ${e.message}.`
                }
                this.loading = false;
            }
        },

        filters: {
            date(value) {
                if (!value) {
                    return "";
                }
                return (new Date(value)).toDateString()
            }
        },
        async created() {
            await this.fetchWeatherForecasts()
        }
    }
</script>

<style>
</style>
