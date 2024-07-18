// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const { createApp } = Vue;
const API_Host = 'https://localhost:7167/';

createApp({
    setup() { },
    onMounted() { },
    data() {
        return {
            engineList: [
                { text: 'Google', value: 0 },
                { text: 'Bing', value: 1 },
                { text: 'Yahoo', value: 2 }],
            status_Loading: false,
            status_Message: '',
            userInput: {
                searchEngine: 0,
                keyWord: 'land registry searches',
                targetURL: 'www.infotrack.co.uk'
            }
        }
    },
    methods: {
        CheckInput()
        {
            var list = [];
            if (!this.userInput.keyWord)
                list.push('must provide a keyword');
            if (!this.userInput.targetURL)
                list.push('must provide a targetURL');

            if (list.length > 0)
            {
                this.status_Message = list;
                return false;
            }
            return true;
        },
        DoSearch() {
            if (!this.CheckInput())
                return;

            var local = this;
            this.status_Message = '';
            this.status_Loading = true;
            const options = {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json' 
                },
                body: JSON.stringify(this.userInput) 
            };
            fetch(API_Host + 'search', options)
                .then(function (response) {
                    if (!response.ok)
                    {
                        local.status_Message = 'Oops, something went wrong';
                        local.status_Loading = false;
                        return;
                    }
                    return response.json();
                })
                .then(data => {
                    if (data.ranking <= 0)
                        this.status_Message = 'no relevant information found, and this seach has been done: ' + data.count + ' times in total';
                    else
                        this.status_Message = 'we got it RANK: # ' + data.rank + ', and this seach has been done: ' + data.count + ' times in total';
                    return fetch(encodeURI(API_Host + 'Rank?SearchEngine=' + this.userInput.searchEngine + '&KeyWord=' + this.userInput.keyWord + '&TargetURL=' + this.userInput.targetURL));
                })
                .then(function (response) {
                    return response.json();
                })
                .then(function (data) {
                    SetMyChart(data);
                    local.status_Loading = false;
                }) .catch(error => {
                    local.status_Message = 'Oops, something went wrong';
                    local.status_Loading = false;
                });
        }
    }
}).mount('#app');

let ctx = document.getElementById('myChart').getContext('2d');
let myChart = GetmyChart();
function GetmyChart() {
    return new Chart(ctx, {
        type: 'line',
        data: {
            labels: [],
            datasets: [{ label: 'Ranking', data: [] }]
        }
    })
};

function SetMyChart(data) {
    myChart.destroy();
    myChart = GetmyChart();
    data.rankings.forEach(x => {
        myChart.data.labels.push(x.key);
        myChart.data.datasets[0].data.push(x.value);
    });
    myChart.update();
};