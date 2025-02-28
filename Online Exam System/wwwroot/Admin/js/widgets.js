(function ($) {
    'use strict';
    $(function () {
        var infoColor = "#2b8ae3";
        var primaryColor = "#b76cf8";
        var secondaryColor = "#c3bdbd";
        var successColor = "#5bcfb5";
        var dangerColor = "#ef7a95";
        var warningColor = "#fbd84a"
        

        function onRefresh(chart) {
            chart.data.datasets.forEach(function (dataset) {
                dataset.data.push({
                    x: Date.now(),
                    y: Math.random()
                });
            });
        }
        var lineChartStyleOption_1 = {
            scales: {
                yAxes: [{
                    display: false
                }],
                xAxes: [{
                    display: false
                }]
            },
            legend: {
                display: false
            },
            elements: {
                point: {
                    radius: 1
                },
                line: {
                    tension: 0
                }
            },
            stepsize: 100
        };
        var lineChartStyleOption_2 = {
            scales: {
                yAxes: [{
                    display: false
                }],
                xAxes: [{
                    display: false
                }]
            },
            legend: {
                display: false
            },
            elements: {
                point: {
                    radius: 0
                },
                line: {
                    tension: 0
                }
            },
            stepsize: 100
        };
        if ($('#statistics-graph-1').length) {
            var lineChartCanvas = $("#statistics-graph-1").get(0).getContext("2d");
            var gradientStrokeFill_1 = lineChartCanvas.createLinearGradient(1, 2, 1, 400);
            gradientStrokeFill_1.addColorStop(0, 'rgba(218, 140, 255, 1)');
            gradientStrokeFill_1.addColorStop(1, infoColor);

            var lineChart = new Chart(lineChartCanvas, {
                type: 'line',
                data: {
                    labels: ["Day 1", "Day 2", "Day 3", "Day 4", "Day 5", "Day 6", "Day 7"],
                    datasets: [{
                        label: 'Profit',
                        data: [3, 9, 7, 5, 7, 2, 8],
                        borderColor: infoColor,
                        backgroundColor: gradientStrokeFill_1,
                        borderWidth: 2,
                        fill: true
                    }]
                },
                options: lineChartStyleOption_2
            });
        }
        if ($('#statistics-graph-2').length) {
            var lineChartCanvas = $("#statistics-graph-2").get(0).getContext("2d");
            var gradientStrokeFill_1 = lineChartCanvas.createLinearGradient(1, 2, 1, 400);
            gradientStrokeFill_1.addColorStop(0, '#fff');
            gradientStrokeFill_1.addColorStop(1, primaryColor);

            var lineChart = new Chart(lineChartCanvas, {
                type: 'line',
                data: {
                    labels: ["Day 1", "Day 2", "Day 3", "Day 4", "Day 5", "Day 6", "Day 7"],
                    datasets: [{
                        label: 'Profit',
                        data: [7, 9, 2, 2, 8, 7, 9],
                        borderColor: primaryColor,
                        backgroundColor: gradientStrokeFill_1,
                        borderWidth: 2,
                        fill: true
                    }]
                },
                options: lineChartStyleOption_2
            });
        }
        if ($('#statistics-graph-3').length) {
            var lineChartCanvas = $("#statistics-graph-3").get(0).getContext("2d");
            var gradientStrokeFill_1 = lineChartCanvas.createLinearGradient(1, 2, 1, 400);
            gradientStrokeFill_1.addColorStop(0, '#fff');
            gradientStrokeFill_1.addColorStop(1, warningColor);

            var lineChart = new Chart(lineChartCanvas, {
                type: 'line',
                data: {
                    labels: ["Day 1", "Day 2", "Day 3", "Day 4", "Day 5", "Day 6", "Day 7"],
                    datasets: [{
                        label: 'Profit',
                        data: [5, 4, 7, 2, 9, 2, 8],
                        borderColor: warningColor,
                        backgroundColor: gradientStrokeFill_1,
                        borderWidth: 2,
                        fill: true
                    }]
                },
                options: lineChartStyleOption_2
            });
        }
        if ($('#statistics-graph-4').length) {
            var lineChartCanvas = $("#statistics-graph-4").get(0).getContext("2d");
            var gradientStrokeFill_1 = lineChartCanvas.createLinearGradient(1, 2, 1, 400);
            gradientStrokeFill_1.addColorStop(0, '#fff');
            gradientStrokeFill_1.addColorStop(1, dangerColor);

            var lineChart = new Chart(lineChartCanvas, {
                type: 'line',
                data: {
                    labels: ["Day 1", "Day 2", "Day 3", "Day 4", "Day 5", "Day 6", "Day 7"],
                    datasets: [{
                        label: 'Profit',
                        data: [5, 2, 5, 2, 4, 4, 1],
                        borderColor: dangerColor,
                        backgroundColor: gradientStrokeFill_1,
                        borderWidth: 2,
                        fill: true
                    }]
                },
                options: lineChartStyleOption_2
            });
        }
        if ($('#statistics-graph-dark1').length) {
            var lineChartCanvas = $("#statistics-graph-dark1").get(0).getContext("2d");
            var gradientStrokeFill_1 = lineChartCanvas.createLinearGradient(1, 2, 1, 400);
            gradientStrokeFill_1.addColorStop(0, '#151519');
            gradientStrokeFill_1.addColorStop(1, infoColor);

            var lineChart = new Chart(lineChartCanvas, {
                type: 'line',
                data: {
                    labels: ["Day 1", "Day 2", "Day 3", "Day 4", "Day 5", "Day 6", "Day 7"],
                    datasets: [{
                        label: 'Profit',
                        data: [3, 9, 7, 5, 7, 2, 8],
                        borderColor: infoColor,
                        backgroundColor: gradientStrokeFill_1,
                        borderWidth: 2,
                        fill: true
                    }]
                },
                options: lineChartStyleOption_2
            });
        }
        if ($('#statistics-graph-dark2').length) {
            var lineChartCanvas = $("#statistics-graph-dark2").get(0).getContext("2d");
            var gradientStrokeFill_1 = lineChartCanvas.createLinearGradient(1, 2, 1, 400);
            gradientStrokeFill_1.addColorStop(0, '#151519');
            gradientStrokeFill_1.addColorStop(1, primaryColor);

            var lineChart = new Chart(lineChartCanvas, {
                type: 'line',
                data: {
                    labels: ["Day 1", "Day 2", "Day 3", "Day 4", "Day 5", "Day 6", "Day 7"],
                    datasets: [{
                        label: 'Profit',
                        data: [7, 9, 2, 2, 8, 7, 9],
                        borderColor: primaryColor,
                        backgroundColor: gradientStrokeFill_1,
                        borderWidth: 2,
                        fill: true
                    }]
                },
                options: lineChartStyleOption_2
            });
        }
        if ($('#statistics-graph-dark3').length) {
            var lineChartCanvas = $("#statistics-graph-dark3").get(0).getContext("2d");
            var gradientStrokeFill_1 = lineChartCanvas.createLinearGradient(1, 2, 1, 400);
            gradientStrokeFill_1.addColorStop(0, '#151519');
            gradientStrokeFill_1.addColorStop(1, warningColor);

            var lineChart = new Chart(lineChartCanvas, {
                type: 'line',
                data: {
                    labels: ["Day 1", "Day 2", "Day 3", "Day 4", "Day 5", "Day 6", "Day 7"],
                    datasets: [{
                        label: 'Profit',
                        data: [5, 4, 7, 2, 9, 2, 8],
                        borderColor: warningColor,
                        backgroundColor: gradientStrokeFill_1,
                        borderWidth: 2,
                        fill: true
                    }]
                },
                options: lineChartStyleOption_2
            });
        }
        if ($('#statistics-graph-dark4').length) {
            var lineChartCanvas = $("#statistics-graph-dark4").get(0).getContext("2d");
            var gradientStrokeFill_1 = lineChartCanvas.createLinearGradient(1, 2, 1, 400);
            gradientStrokeFill_1.addColorStop(0, '#151519');
            gradientStrokeFill_1.addColorStop(1, dangerColor);

            var lineChart = new Chart(lineChartCanvas, {
                type: 'line',
                data: {
                    labels: ["Day 1", "Day 2", "Day 3", "Day 4", "Day 5", "Day 6", "Day 7"],
                    datasets: [{
                        label: 'Profit',
                        data: [5, 2, 5, 2, 4, 4, 1],
                        borderColor: dangerColor,
                        backgroundColor: gradientStrokeFill_1,
                        borderWidth: 2,
                        fill: true
                    }]
                },
                options: lineChartStyleOption_2
            });
        }
        if ($('#review-rating-1').length) {
            $('#review-rating-1').barrating({
                theme: 'css-stars',
                showSelectedRating: false,
                initialRating: 4
            });
        }
        if ($('#review-rating-2').length) {
            $('#review-rating-2').barrating({
                theme: 'css-stars',
                showSelectedRating: false,
                initialRating: 5
            });
        }
        if ($('#review-rating-3').length) {
            $('#review-rating-3').barrating({
                theme: 'css-stars',
                showSelectedRating: false,
                initialRating: 3
            });
        }
        if ($('#review-rating-4').length) {
            $('#review-rating-4').barrating({
                theme: 'css-stars',
                showSelectedRating: false,
                initialRating: 4
            });
        }
        if ($('#review-rating-5').length) {
            $('#review-rating-5').barrating({
                theme: 'css-stars',
                showSelectedRating: false,
                initialRating: 2
            });
        }
        if ($("#UsersDoughnutChart").length) {
            var doughnutChartCanvas = $("#UsersDoughnutChart").get(0).getContext("2d");
            var doughnutPieData = {
                datasets: [{
                    data: [80, 34, 100],
                    backgroundColor: [
                        successColor,
                        infoColor,
                        secondaryColor
                    ],
                    borderColor: [
                        successColor,
                        infoColor,
                        secondaryColor
                    ],
                }],
                labels: [
                    'Request',
                    'Email',
                ]
            };
            var doughnutPieOptions = {
                cutoutPercentage: 70,
                animationEasing: "easeOutBounce",
                animateRotate: true,
                animateScale: false,
                responsive: true,
                maintainAspectRatio: true,
                showScale: true,
                legend: {
                    display: false
                },
                layout: {
                    padding: {
                        left: 0,
                        right: 0,
                        top: 0,
                        bottom: 0
                    }
                }
            };
            var doughnutChart = new Chart(doughnutChartCanvas, {
                type: 'doughnut',
                data: doughnutPieData,
                options: doughnutPieOptions
            });
        }
        if ($('#conversionBarChart').length) {
            var barChartCanvas = $("#conversionBarChart").get(0).getContext("2d");
            var barChart = new Chart(barChartCanvas, {
                type: 'bar',
                data: {
                    labels: ["Day 1", "Day 2", "Day 3", "Day 4", "Day 5", "Day 6", "Day 7", "Day 8", "Day 9", "Day 10"],
                    datasets: [{
                        label: 'Amount Due',
                        data: [39, 19, 25, 16, 31, 39, 12, 18, 33, 24],
                        backgroundColor: primaryColor,
                        borderColor: primaryColor,
                        borderWidth: 0
                    }]
                },
                options: {
                    layout: {
                        padding: {
                            left: 0,
                            right: 0,
                            top: 0,
                            bottom: 0
                        }
                    },

                    scales: {
                        responsive: true,
                        maintainAspectRatio: true,
                        yAxes: [{
                            display: false,
                            gridLines: {
                                color: 'rgba(0, 0, 0, 0.03)',
                            }
                        }],
                        xAxes: [{
                            display: false,
                            barPercentage: 0.4,
                            gridLines: {
                                display: false,
                            }
                        }]
                    },
                    legend: {
                        display: false
                    }
                }
            });
        }
        if ($("#trafficSourceDoughnutChart").length) {
            var doughnutChartCanvas = $("#trafficSourceDoughnutChart").get(0).getContext("2d");
            var doughnutPieData = {
                datasets: [{
                    data: [185, 85, 15],
                    backgroundColor: [
                        secondaryColor,
                        successColor,
                        dangerColor,

                    ],
                    borderColor: [
                        secondaryColor,
                        successColor,
                        dangerColor,

                    ],
                }],

                // These labels appear in the legend and in the tooltips when hovering different arcs
                labels: [
                    'Human Resources',
                    'Manger',
                    'Other'
                ]
            };
            var doughnutPieOptions = {
                cutoutPercentage: 75,
                animationEasing: "easeOutBounce",
                animateRotate: true,
                animateScale: false,
                responsive: true,
                maintainAspectRatio: true,
                showScale: true,
                legend: {
                    display: false
                },
                layout: {
                    padding: {
                        left: 0,
                        right: 0,
                        top: 0,
                        bottom: 0
                    }
                }
            };
            var doughnutChart = new Chart(doughnutChartCanvas, {
                type: 'doughnut',
                data: doughnutPieData,
                options: doughnutPieOptions
            });
        }
        if ($('#usersDoughnutChart').length) {
            var g1
            var g1 = new JustGage({
                id: "usersDoughnutChart",
                value: getRandomInt(0, 100),
                min: 0,
                max: 100,
                gaugeWidthScale: 0.8,
                hideInnerShadow: true,
                customSectors: [{
                    color: dangerColor,
                    lo: 0,
                    hi: 25
                }, {
                    color: warningColor,
                    lo: 25,
                    hi: 50
                }, {
                    color: successColor,
                    lo: 50,
                    hi: 100
                }],
                label: "Daily average"
            });


            setInterval(function () {
                g1.refresh(getRandomInt(20, 100));
            }, 3500);
        }
        if ($("#visit-sale-chart").length) {
          Chart.defaults.global.legend.labels.usePointStyle = true;
          var ctx = document.getElementById('visit-sale-chart').getContext("2d");
    
          var gradientStrokeViolet = ctx.createLinearGradient(0, 0, 0, 181);
          gradientStrokeViolet.addColorStop(0, 'rgba(218, 140, 255, 1)');
          gradientStrokeViolet.addColorStop(1, 'rgba(154, 85, 255, 1)');
          var gradientLegendViolet = 'linear-gradient(to right, rgba(218, 140, 255, 1), rgba(154, 85, 255, 1))';
          
          var gradientStrokeBlue = ctx.createLinearGradient(0, 0, 0, 360);
          gradientStrokeBlue.addColorStop(0, 'rgba(54, 215, 232, 1)');
          gradientStrokeBlue.addColorStop(1, 'rgba(177, 148, 250, 1)');
          var gradientLegendBlue = 'linear-gradient(to right, rgba(54, 215, 232, 1), rgba(177, 148, 250, 1))';
    
          var gradientStrokeRed = ctx.createLinearGradient(0, 0, 0, 300);
          gradientStrokeRed.addColorStop(0, 'rgba(255, 191, 150, 1)');
          gradientStrokeRed.addColorStop(1, 'rgba(254, 112, 150, 1)');
          var gradientLegendRed = 'linear-gradient(to right, rgba(255, 191, 150, 1), rgba(254, 112, 150, 1))';
    
          var myChart = new Chart(ctx, {
            type: 'bar',
            data: {
                labels: ['JAN', 'FEB', 'MAR', 'APR', 'MAY', 'JUN', 'JUL', 'AUG'],
                datasets: [
                  {
                    label: "CHN",
                    borderColor: gradientStrokeViolet,
                    backgroundColor: gradientStrokeViolet,
                    hoverBackgroundColor: gradientStrokeViolet,
                    legendColor: gradientLegendViolet,
                    pointRadius: 0,
                    fill: false,
                    borderWidth: 1,
                    fill: 'origin',
                    data: [20, 40, 15, 35, 25, 50, 30, 20]
                  },
                  {
                    label: "USA",
                    borderColor: gradientStrokeRed,
                    backgroundColor: gradientStrokeRed,
                    hoverBackgroundColor: gradientStrokeRed,
                    legendColor: gradientLegendRed,
                    pointRadius: 0,
                    fill: false,
                    borderWidth: 1,
                    fill: 'origin',
                    data: [40, 30, 20, 10, 50, 15, 35, 40]
                  },
                  {
                    label: "UK",
                    borderColor: gradientStrokeBlue,
                    backgroundColor: gradientStrokeBlue,
                    hoverBackgroundColor: gradientStrokeBlue,
                    legendColor: gradientLegendBlue,
                    pointRadius: 0,
                    fill: false,
                    borderWidth: 1,
                    fill: 'origin',
                    data: [70, 10, 30, 40, 25, 50, 15, 30]
                  }
              ]
            },
            options: {
              responsive: true,
              legend: false,
              legendCallback: function(chart) {
                var text = []; 
                text.push('<ul>'); 
                for (var i = 0; i < chart.data.datasets.length; i++) { 
                    text.push('<li><span class="legend-dots" style="background:' + 
                               chart.data.datasets[i].legendColor + 
                               '"></span>'); 
                    if (chart.data.datasets[i].label) { 
                        text.push(chart.data.datasets[i].label); 
                    } 
                    text.push('</li>'); 
                } 
                text.push('</ul>'); 
                return text.join('');
              },
              scales: {
                  yAxes: [{
                      ticks: {
                          display: false,
                          min: 0,
                          stepSize: 20,
                          max: 80
                      },
                      gridLines: {
                        drawBorder: false,
                        color: 'rgba(235,237,242,1)',
                        zeroLineColor: 'rgba(235,237,242,1)'
                      }
                  }],
                  xAxes: [{
                      gridLines: {
                        display:false,
                        drawBorder: false,
                        color: 'rgba(0,0,0,1)',
                        zeroLineColor: 'rgba(235,237,242,1)'
                      },
                      ticks: {
                          padding: 20,
                          fontColor: "#9c9fa6",
                          autoSkip: true,
                      },
                      categoryPercentage: 0.5,
                      barPercentage: 0.5
                  }]
                }
              },
              elements: {
                point: {
                  radius: 0
                }
              }
          })
          $("#visit-sale-chart-legend").html(myChart.generateLegend());
        }
        if ($("#visit-sale-chart-dark").length) {
          Chart.defaults.global.legend.labels.usePointStyle = true;
          var ctx = document.getElementById('visit-sale-chart-dark').getContext("2d");
    
          var gradientStrokeViolet = ctx.createLinearGradient(0, 0, 0, 181);
          gradientStrokeViolet.addColorStop(0, 'rgba(218, 140, 255, 1)');
          gradientStrokeViolet.addColorStop(1, 'rgba(154, 85, 255, 1)');
          var gradientLegendViolet = 'linear-gradient(to right, rgba(218, 140, 255, 1), rgba(154, 85, 255, 1))';
          
          var gradientStrokeBlue = ctx.createLinearGradient(0, 0, 0, 360);
          gradientStrokeBlue.addColorStop(0, 'rgba(54, 215, 232, 1)');
          gradientStrokeBlue.addColorStop(1, 'rgba(177, 148, 250, 1)');
          var gradientLegendBlue = 'linear-gradient(to right, rgba(54, 215, 232, 1), rgba(177, 148, 250, 1))';
    
          var gradientStrokeRed = ctx.createLinearGradient(0, 0, 0, 300);
          gradientStrokeRed.addColorStop(0, 'rgba(255, 191, 150, 1)');
          gradientStrokeRed.addColorStop(1, 'rgba(254, 112, 150, 1)');
          var gradientLegendRed = 'linear-gradient(to right, rgba(255, 191, 150, 1), rgba(254, 112, 150, 1))';
    
          var myChart = new Chart(ctx, {
            type: 'bar',
            data: {
                labels: ['JAN', 'FEB', 'MAR', 'APR', 'MAY', 'JUN', 'JUL', 'AUG'],
                datasets: [
                  {
                    label: "CHN",
                    borderColor: gradientStrokeViolet,
                    backgroundColor: gradientStrokeViolet,
                    hoverBackgroundColor: gradientStrokeViolet,
                    legendColor: gradientLegendViolet,
                    pointRadius: 0,
                    fill: false,
                    borderWidth: 1,
                    fill: 'origin',
                    data: [20, 40, 15, 35, 25, 50, 30, 20]
                  },
                  {
                    label: "USA",
                    borderColor: gradientStrokeRed,
                    backgroundColor: gradientStrokeRed,
                    hoverBackgroundColor: gradientStrokeRed,
                    legendColor: gradientLegendRed,
                    pointRadius: 0,
                    fill: false,
                    borderWidth: 1,
                    fill: 'origin',
                    data: [40, 30, 20, 10, 50, 15, 35, 40]
                  },
                  {
                    label: "UK",
                    borderColor: gradientStrokeBlue,
                    backgroundColor: gradientStrokeBlue,
                    hoverBackgroundColor: gradientStrokeBlue,
                    legendColor: gradientLegendBlue,
                    pointRadius: 0,
                    fill: false,
                    borderWidth: 1,
                    fill: 'origin',
                    data: [70, 10, 30, 40, 25, 50, 15, 30]
                  }
              ]
            },
            options: {
              responsive: true,
              legend: false,
              legendCallback: function(chart) {
                var text = []; 
                text.push('<ul>'); 
                for (var i = 0; i < chart.data.datasets.length; i++) { 
                    text.push('<li><span class="legend-dots" style="background:' + 
                               chart.data.datasets[i].legendColor + 
                               '"></span>'); 
                    if (chart.data.datasets[i].label) { 
                        text.push(chart.data.datasets[i].label); 
                    } 
                    text.push('</li>'); 
                } 
                text.push('</ul>'); 
                return text.join('');
              },
              scales: {
                  yAxes: [{
                      ticks: {
                          display: false,
                          min: 0,
                          stepSize: 20,
                          max: 80
                      },
                      gridLines: {
                        drawBorder: false,
                        color: '#322f2f',
                        zeroLineColor: '#322f2f'
                      }
                  }],
                  xAxes: [{
                      gridLines: {
                        display:false,
                        drawBorder: false,
                        color: 'rgba(0,0,0,1)',
                        zeroLineColor: 'rgba(235,237,242,1)'
                      },
                      ticks: {
                          padding: 20,
                          fontColor: "#9c9fa6",
                          autoSkip: true,
                      },
                      categoryPercentage: 0.5,
                      barPercentage: 0.5
                  }]
                }
              },
              elements: {
                point: {
                  radius: 0
                }
              }
          })
          $("#visit-sale-chart-legend-dark").html(myChart.generateLegend());
        }
        if ($("#traffic-chart").length) {
          var gradientStrokeBlue = ctx.createLinearGradient(0, 0, 0, 181);
          gradientStrokeBlue.addColorStop(0, 'rgba(54, 215, 232, 1)');
          gradientStrokeBlue.addColorStop(1, 'rgba(177, 148, 250, 1)');
          var gradientLegendBlue = 'linear-gradient(to right, rgba(54, 215, 232, 1), rgba(177, 148, 250, 1))';
    
          var gradientStrokeRed = ctx.createLinearGradient(0, 0, 0, 50);
          gradientStrokeRed.addColorStop(0, 'rgba(255, 191, 150, 1)');
          gradientStrokeRed.addColorStop(1, 'rgba(254, 112, 150, 1)');
          var gradientLegendRed = 'linear-gradient(to right, rgba(255, 191, 150, 1), rgba(254, 112, 150, 1))';
    
          var gradientStrokeGreen = ctx.createLinearGradient(0, 0, 0, 300);
          gradientStrokeGreen.addColorStop(0, 'rgba(6, 185, 157, 1)');
          gradientStrokeGreen.addColorStop(1, 'rgba(132, 217, 210, 1)');
          var gradientLegendGreen = 'linear-gradient(to right, rgba(6, 185, 157, 1), rgba(132, 217, 210, 1))';      
    
          var trafficChartData = {
            datasets: [{
              data: [30, 30, 40],
              backgroundColor: [
                gradientStrokeBlue,
                gradientStrokeGreen,
                gradientStrokeRed
              ],
              hoverBackgroundColor: [
                gradientStrokeBlue,
                gradientStrokeGreen,
                gradientStrokeRed
              ],
              borderColor: [
                gradientStrokeBlue,
                gradientStrokeGreen,
                gradientStrokeRed
              ],
              legendColor: [
                gradientLegendBlue,
                gradientLegendGreen,
                gradientLegendRed
              ]
            }],
        
            // These labels appear in the legend and in the tooltips when hovering different arcs
            labels: [
              'Search Engines',
              'Direct Click',
              'Bookmarks Click',
            ]
          };
          var trafficChartOptions = {
            responsive: true,
            animation: {
              animateScale: true,
              animateRotate: true
            },
            legend: false,
            legendCallback: function(chart) {
              var text = []; 
              text.push('<ul>'); 
              for (var i = 0; i < trafficChartData.datasets[0].data.length; i++) { 
                  text.push('<li><span class="legend-dots" style="background:' + 
                  trafficChartData.datasets[0].legendColor[i] + 
                              '"></span>'); 
                  if (trafficChartData.labels[i]) { 
                      text.push(trafficChartData.labels[i]); 
                  }
                  text.push('<span class="float-right">'+trafficChartData.datasets[0].data[i]+"%"+'</span>')
                  text.push('</li>'); 
              } 
              text.push('</ul>'); 
              return text.join('');
            }
          };
          var trafficChartCanvas = $("#traffic-chart").get(0).getContext("2d");
          var trafficChart = new Chart(trafficChartCanvas, {
            type: 'doughnut',
            data: trafficChartData,
            options: trafficChartOptions
          });
          $("#traffic-chart-legend").html(trafficChart.generateLegend());      
        }
    });
})(jQuery)