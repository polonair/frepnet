namespace frep2
{
    static class TemplateFile
    {
        internal static string Individual_Query_Default_Template {
            get {
return @"
<html>
<head>
        <title></title>
</head>
<body>
        <h1>#{{ currentFund.FundID }} '{{ currentFund.fundName }}'</h1>
        <p>note1 : {{ currentFund.note1 }}</p>
        <p>note2 : {{ currentFund.note2 }}</p>
        <p>note3 : {{ currentFund.note3 }}</p>
        <p>note4 : {{ currentFund.note4 }}</p>
        <p>note5 : {{ currentFund.note5 }}</p>
        <p>note6 : {{ currentFund.note6 }}</p>
        <p>note7 : {{ currentFund.note7 }}</p>
        <p>fundLaunchDate : {{ currentFund.fundLaunchDate }}</p>
        <p>fundName : {{ currentFund.fundName }}</p>
        <p>totalBondSales : {{ currentFund.totalBondSales }}</p>
        <p>yesterdayNAV : {{ currentFund.yesterdayNAV }}</p>
        <p>todayNAV : {{ currentFund.todayNAV }}</p>
        <p>changeInNAV : {{ currentFund.changeInNAV }}</p>
        <p>percentageChangeInNAV : {{ currentFund.percentageChangeInNAV }}</p>
        <p>performanceScore : {{ currentFund.performanceScore }}</p>
        <p>valueResearchRating : {{ currentFund.valueResearchRating }}</p>
        <p>todayRating : {{ currentFund.todayRating }}</p>
        <p>todaySales : {{ currentFund.todaySales }}</p>
        <p>performanceScore20 : {{ currentFund.performanceScore20 }}</p>
        <p>valueResearchRating20 : {{ currentFund.valueResearchRating20 }}</p>
        <p>totalBondSales20 : {{ currentFund.totalBondSales20 }}</p>
        <p>performanceImprovementPercentage : {{ currentFund.performanceImprovementPercentage }}</p>
        <p>previousNAV : {{ currentFund.previousNAV }}</p>
        <p>lowestNAV : {{ currentFund.lowestNAV }}</p>
        <p>highestNAV : {{ currentFund.highestNAV }}</p>
        <p>navChange : {{ currentFund.navChange }}</p>
        <p>navChangePercentage : {{ currentFund.navChangePercentage }}</p>
        <p>navChangeLong : {{ currentFund.navChangeLong }}</p>
        <p>navChangeLongPercentage : {{ currentFund.navChangeLongPercentage }}</p>
<HR>
        <p>day1NAV : {{ currentFund.day1NAV }}</p>
        <p>day2NAV : {{ currentFund.day2NAV }}</p>
        <p>day3NAV : {{ currentFund.day3NAV }}</p>
        <p>day4NAV : {{ currentFund.day4NAV }}</p>
        <p>day5NAV : {{ currentFund.day5NAV }}</p>
        <p>day6NAV : {{ currentFund.day6NAV }}</p>
        <p>day7NAV : {{ currentFund.day7NAV }}</p>
        <p>day8NAV : {{ currentFund.day8NAV }}</p>
        <p>day9NAV : {{ currentFund.day9NAV }}</p>
        <p>day10NAV : {{ currentFund.day10NAV }}</p>
        <p>day11NAV : {{ currentFund.day11NAV }}</p>
        <p>day12NAV : {{ currentFund.day12NAV }}</p>
        <p>day13NAV : {{ currentFund.day13NAV }}</p>
        <p>day14NAV : {{ currentFund.day14NAV }}</p>
        <p>day15NAV : {{ currentFund.day15NAV }}</p>
        <p>day16NAV : {{ currentFund.day16NAV }}</p>
        <p>day17NAV : {{ currentFund.day17NAV }}</p>
        <p>day18NAV : {{ currentFund.day18NAV }}</p>
        <p>day19NAV : {{ currentFund.day19NAV }}</p>
        <p>day20NAV : {{ currentFund.day20NAV }}</p>
<HR>
        <h2>By Category</h2>
        {% for category in currentFund.Categories %}
            <h3>{{ category }}</h3>
            {% capture fundCategory %}{{ category }}{% endcapture %}
            <p>overallScoreRank : {{ currentFund.overallScoreRank }}</p>
            <p>performanceScoreRank : {{ currentFund.performanceScoreRank }}</p>
            <p>highestRatingRank : {{ currentFund.highestRatingRank }}</p>
            <p>performanceImprovementPercentageRank : {{ currentFund.performanceImprovementPercentageRank }}</p>
            <p>valueResearchRatingRank : {{ currentFund.valueResearchRatingRank }}</p>
            <p>overallScore : {{ currentFund.overallScore }}</p>
        {% endfor %}
            <h3>All</h3>
            {% capture fundCategory %}All{% endcapture %}
            <p>overallScoreRank : {{ currentFund.overallScoreRank }}</p>
            <p>performanceScoreRank : {{ currentFund.performanceScoreRank }}</p>
            <p>highestRatingRank : {{ currentFund.highestRatingRank }}</p>
            <p>performanceImprovementPercentageRank : {{ currentFund.performanceImprovementPercentageRank }}</p>
            <p>valueResearchRatingRank : {{ currentFund.valueResearchRatingRank }}</p>
            <p>overallScore : {{ currentFund.overallScore }}</p>
<HR>
        <p>Generated on {{ date|Date:""d MMMM yyyy"" }}</p>
</body>
</html>
";
            }
        }
        internal static string Query_1_Default_Template {
            get {
return @"
<html>
<head>
    <title></title>
</head>
<body>
    <h1>Results for: {{fundCategory}}</h1>
    <table border = 1 >
        <tr>
            <th> Note 1</th>
            <th>Fund Name</th>
            <th>Value Research Rating as on Today</th>
            <th>Total Bond Sales in Rs (Crores) as on 3.30pm Today</th>
            <th>Performance Score Rank</th>
            <th>Yesterday NAV</th>
            <th>Today's NAV</th>
            <th>Note 2</th>
            <th>Change in NAV</th>
            <th>% Change in NAV</th>
        </tr>
        {% for currentFund in mutualFunds -%}
        <tr>
            <td>{{ currentFund.note1 }}</td>
            <td>{{ currentFund.fundName }}</td>
            <td>{{ currentFund.valueResearchRating }}</td>
            <td>{{ currentFund.totalBondSales }}</td>
            <td>{{ currentFund.performanceScoreRank }}</td>
            <td>{{ currentFund.yesterdayNAV|FrepNavFormat }}</td>
            <td>{{ currentFund.todayNAV|FrepNavFormat }}</td>
            <td>{{ currentFund.note2 }}</td>
            <td>{{ currentFund.changeInNAV|Round:0 }}</td>
            <td>{{ currentFund.percentageChangeInNAV|Round:2 }}</td>
        </tr>
        {% endfor -%}
    </table>
    <p>Page {{ currentPage }} of {{ totalPages }}</p>
    <p>Generated on {{ date|Date:""d MMMM yyyy"" }}</p>
</body>
</html>";
            }
        }
        internal static string Query_2_Default_Template {
            get {
return @"
<html>
<head>
    <title></title>
</head>
<body>
    <h1>Results for: {{fundCategory}}</h1>
    <table border=1>
        <tr>
            <th>Note 1</th>
            <th>Fund Name</th>
            <th>Value Research Rating as on Today</th>
            <th>Total Bond Sales in Rs (Crores) as on 3.30pm Today</th>
            <th>Performance Score Rank</th>
            <th>Yesterday NAV</th>
            <th>Today's NAV</th>
            <th>Note 2</th>
            <th>Change in NAV</th>
            <th>% Change LONG in NAV</th>
        </tr>
        {% for currentFund in mutualFunds %}
        <tr>
            <td>{{currentFund.note1}}</td>
            <td>{{currentFund.fundName}}</td>
            <td>{{currentFund.valueResearchRating}}</td>
            <td>{{currentFund.totalBondSales}}</td>
            <td>{{currentFund.performanceScoreRank}}</td>
            <td>{{currentFund.yesterdayNAV|FrepNavFormat}}</td>
            <td>{{currentFund.todayNAV|FrepNavFormat}}</td>
            <td>{{currentFund.note2}}</td>
            <td>{{currentFund.changeInNAV|Round:0}}</td>
            <td>{{currentFund.navChangeLongPercentage|Round:2}}</td>
        {% endfor %}
        </tr>
    </table>
    <p>Page {{currentPage}} of {{totalPages}}</p>
    <p>Generated on {{date|Date:""d MMMM yyyy""}}</p>
</body>
</html>";
            }
        }
        internal static string Query_3_Default_Template {
            get {
return @"
<html>
<head>
    <title></title>
</head>
<body>
    <h1>Results for: {{fundCategory}}</h1>
    <table border=1>
        <tr>
            <th>Note 1</th>
            <th>Fund Name</th>
            <th>Value Research Rating as on Today</th>
            <th>Total Bond Sales in Rs (Crores) as on 3.30pm Today</th>
            <th>Fund Launch Date</th>
            <th>No. Of Days Since Launch</th>
            <th>Performance Score</th>
            <th>Performance Score Rank</th>
            <th>% Performance Improvement</th>
            <th>NAV as of today</th>
            <th>Note 2</th>
        </tr>
        {% for currentFund in mutualFunds %}
        <tr>
            <td>{{currentFund.note1}}</td>
            <td>{{currentFund.fundName}}</td>
            <td>{{currentFund.valueResearchRating}}</td>
            <td>{{currentFund.totalBondSales}}</td>
            <td>{{currentFund.fundLaunchDate|Date:""d MMMM yyyy"" }}</td>
            <td>{{currentFund.daysSinceLaunch}}</td>
            <td>{{currentFund.performanceScore|Round:2}}</td>
            <td>{{currentFund.performanceScoreRank}}</td>
            <td>{{currentFund.performanceImprovementPercentage|Round:2}}</td>
            <td>{{currentFund.todayNAV|FrepNavFormat}}</td>
            <td>{{currentFund.note2}}</td>
        </tr>
        {% endfor %}
    </table>
    <p>Page {{currentPage}} of {{totalPages}}</p>
    <p>Generated on {{date|Date:""d MMMM yyyy""}}</p>
</body>
</html>";
            }
        }
        internal static string Query_4_Default_Template {
            get {
return @"
<html>
<head>
    <title></title>
</head>
<body>
    <h1>Results for: {{fundCategory}}</h1>
    <table border=1>
        <tr>
            <th>Note 1</th>
            <th>Fund Name</th>
            <th>Value Research Rating as on Today</th>
            <th>Total Bond Sales in Rs (Crores) as on 3.30pm Today</th>
            <th>Fund Launch Date</th>
            <th>No. Of Days Since Launch</th>
            <th>Performance Score</th>
            <th>Performance Improvement % Rank</th>
            <th>% Performance Improvement</th>
            <th>NAV as of today</th>
            <th>Note 2</th>
        </tr>
        {% for currentFund in mutualFunds %}
        <tr>
            <td>{{currentFund.note1}}</td>
            <td>{{currentFund.fundName}}</td>
            <td>{{currentFund.valueResearchRating}}</td>
            <td>{{currentFund.totalBondSales}}</td>
            <td>{{currentFund.fundLaunchDate|Date:""d MMMM yyyy""}}</td>
            <td>{{currentFund.daysSinceLaunch}}</td>
            <td>{{currentFund.performanceScore|Round:2}}</td>
            <td>{{currentFund.performanceImprovementPercentageRank}}</td>
            <td>{{currentFund.performanceImprovementPercentage|Round:2}}</td>
            <td>{{currentFund.todayNAV|FrepNavFormat}}</td>
            <td>{{currentFund.note2}}</td>
        {% endfor %}
        </tr>
    </table>
    <p>Page {{currentPage}} of {{totalPages}}</p>
    <p>Generated on {{date|Date:""d MMMM yyyy""}}</p>
</body>
</html>";
            }
        }
        internal static string Query_5_Default_Template {
            get {
return @"
<html>
<head>
    <title></title>
</head>
<body>
    <h1>Results for: {{fundCategory}}</h1>
    <table border=1>
        <tr>
            <th>Note 1</th>
            <th>Fund Name</th>
            <th>Value Research Rating as on Today</th>
            <th>Total Bond Sales in Rs (Crores) as on 3.30pm Today</th>
            <th>Fund Launch Date</th>
            <th>No. Of Days Since Launch</th>
            
            <th>Value Research Rating Rank</th>
            <th>NAV as of today</th>
            <th>Note 2</th>
        </tr>
        {% for currentFund in mutualFunds %}
        <tr>
            <td>{{currentFund.note1}}</td>
            <td>{{currentFund.fundName}}</td>
            <td>{{currentFund.valueResearchRating}}</td>
            <td>{{currentFund.totalBondSales}}</td>
            <td>{{currentFund.fundLaunchDate|Date:""d MMMM yyyy""}}</td>
            <td>{{currentFund.daysSinceLaunch}}</td>
            <td>{{currentFund.valueResearchRatingRank}}</td>
            <td>{{currentFund.todayNAV|FrepNavFormat}}</td>
            <td>{{currentFund.note2}}</td>
        {% endfor %}
        </tr>
    </table>
    <p>Page {{currentPage}} of {{totalPages}}</p>
    <p>Generated on {{date|Date:""d MMMM yyyy""}}</p>
</body>
</html>";
            }
        }
        internal static string Query_6_Default_Template {
            get {
return @"<html>
<head>
    <title></title>
</head>
<body>
    <h1>Results for: {{fundCategory}}</h1>
    <table border=1>
        <tr>
            <th>Note 1</th>
            <th>Fund Name</th>
            <th>Value Research Rating as on Today</th>
            <th>Total Bond Sales in Rs (Crores) as on 3.30pm Today</th>
            <th>Fund Launch Date</th>
            <th>No. Of Days Since Launch</th>
            <th>NAV as of today</th>
            <th>Note 2</th>
        </tr>
        {% for currentFund in mutualFunds %}
        <tr>
            <td>{{currentFund.note1}}</td>
            <td>{{currentFund.fundName}}</td>
            <td>{{currentFund.valueResearchRating}}</td>
            <td>{{currentFund.totalBondSales}}</td>
            <td>{{currentFund.fundLaunchDate|Date:""d MMMM yyyy""}}</td>
            <td>{{currentFund.daysSinceLaunch}}</td>
            <td>{{currentFund.todayNAV|FrepNavFormat}}</td>
            <td>{{currentFund.note2}}</td>
        {% endfor %}
        </tr>
    </table>
    <p>Page {{currentPage}} of {{totalPages}}</p>
    <p>Generated on {{date|Date:""d MMMM yyyy""}}</p>
</body>
</html>";
            }
        }
        internal static string Query_7_Default_Template {
            get {
return @"<html>
<head>
    <title></title>
</head>
<body>
    <h1>Results for: {{fundCategory}}</h1>
    <table border=1>
        <tr>
            <th>Note 1</th>
            <th>Fund Name</th>
            <th>Value Research Rating as on Today</th>
            <th>Total Bond Sales in Rs (Crores) as on 3.30pm Today</th>
            <th>Fund Launch Date</th>
            <th>No. Of Days Since Launch</th>
            <th>Overall Score</th>
            <th>Performance Score Rank</th>
            <th>Performance Improvement % Rank</th>
            <th>Highest Rating Rank</th>
            <th>NAV as of today</th>
            <th>Note 2</th>
        </tr>
        {% for currentFund in mutualFunds %}
        <tr>
            <td>{{currentFund.note1}}</td>
            <td>{{currentFund.fundName}}</td>
            <td>{{currentFund.valueResearchRating}}</td>
            <td>{{currentFund.totalBondSales}}</td>
            <td>{{currentFund.fundLaunchDate|Date:""d MMMM yyyy""}}</td>
            <td>{{currentFund.daysSinceLaunch}}</td>
            <td>{{currentFund.overallScore}}</td>
            <td>{{currentFund.performanceScoreRank}}</td>
            <td>{{currentFund.performanceImprovementPercentageRank}}</td>
            <td>{{currentFund.highestRatingRank}}</td>
            <td>{{currentFund.todayNAV|FrepNavFormat}}</td>
            <td>{{currentFund.note2}}</td>
        {% endfor %}
        </tr>
    </table>
    <p>Page {{currentPage}} of {{totalPages}}</p>
    <p>Generated on {{date|Date:""d MMMM yyyy""}}</p>
</body>
</html>";
            }
        }
        internal static string Query_8_Default_Template {
            get {
return @"<html>
<head>
    <title></title>
</head>
<body>
    <h1>Results for: {{fundCategory}}</h1>
    <table border=1>
        <tr>
            <th>Note 1</th>
            <th>Fund Name</th>
            <th>Value Research Rating as on Today</th>
            <th>Total Bond Sales in Rs (Crores) as on 3.30pm Today</th>
            <th>Performance Score Rank</th>
            <th>Yesterday NAV</th>
            <th>Today's NAV</th>
            <th>Note 2</th>
            <th>Change in NAV</th>
            <th>% Change in NAV</th>
        </tr>
        {% for currentFund in mutualFunds %}
        <tr>
            <td>{{currentFund.note1}}</td>
            <td>{{currentFund.fundName}}</td>
            <td>{{currentFund.valueResearchRating}}</td>
            <td>{{currentFund.totalBondSales}}</td>
            <td>{{currentFund.performanceScoreRank}}</td>
            <td>{{currentFund.yesterdayNAV|FrepNavFormat}}</td>
            <td>{{currentFund.todayNAV|FrepNavFormat}}</td>
            <td>{{currentFund.note2}}</td>
            <td>{{currentFund.changeInNAV|Round:0}}</td>
            <td>{{currentFund.percentageChangeInNAV|Round:2}}</td>
        {% endfor %}
        </tr>
    </table>
    <p>Page {{currentPage}} of {{totalPages}}</p>
    <p>Generated on {{date|Date:""d MMMM yyyy""}}</p>
</body>
</html>";
            }
        }
        internal static string Query_9_Default_Template {
            get {
return @"<html>
<head>
    <title></title>
</head>
<body>
    <h1>Results for: {{fundCategory}}</h1>
    <table border=1>
        <tr>
            <th>Note 1</th>
            <th>Fund Name</th>
            <th>Value Research Rating as on Today</th>
            <th>Total Bond Sales in Rs (Crores) as on 3.30pm Today</th>
            <th>Performance Score Rank</th>
            <th>Yesterday NAV</th>
            <th>Today's NAV</th>
            <th>Note 2</th>
            <th>Change in NAV</th>
            <th>% Change in NAV</th>
        </tr>
        {% for currentFund in mutualFunds %}
        <tr>
            <td>{{currentFund.note1}}</td>
            <td>{{currentFund.fundName}}</td>
            <td>{{currentFund.valueResearchRating}}</td>
            <td>{{currentFund.totalBondSales}}</td>
            <td>{{currentFund.performanceScoreRank}}</td>
            <td>{{currentFund.yesterdayNAV|FrepNavFormat}}</td>
            <td>{{currentFund.todayNAV|FrepNavFormat}}</td>
            <td>{{currentFund.note2}}</td>
            <td>{{currentFund.changeInNAV|Round:0}}</td>
            <td>{{currentFund.percentageChangeInNAV|Round:2}}</td>
        {% endfor %}
        </tr>
    </table>
    <p>Page {{currentPage}} of {{totalPages}}</p>
    <p>Generated on {{date|Date:""d MMMM yyyy""}}</p>
</body>
</html>";
            }
        }
        internal static string Query_10_Default_Template {
            get {
return @"<html>
<head>
    <title></title>
</head>
<body>
    <h1>Results for: {{fundCategory}}</h1>
    <table border=1>
        <tr>
            <th>Note 1</th>
            <th>Fund Name</th>
            <th>Value Research Rating as on Today</th>
            <th>Total Bond Sales in Rs (Crores) as on 3.30pm Today</th>
            <th>Fund Launch Date</th>
            <th>No. Of Days Since Launch</th>
            <th>Performance Score</th>
            <th>Performance Score Rank</th>
            <th>% Performance Improvement</th>
            <th>NAV as of today</th>
            <th>Note 2</th>
        </tr>
        {% for currentFund in mutualFunds %}
        <tr>
            <td>{{currentFund.note1}}</td>
            <td>{{currentFund.fundName}}</td>
            <td>{{currentFund.valueResearchRating}}</td>
            <td>{{currentFund.totalBondSales}}</td>
            <td>{{currentFund.fundLaunchDate|Date:""d MMMM yyyy""}}</td>
            <td>{{currentFund.daysSinceLaunch}}</td>
            <td>{{currentFund.performanceScore|Round:2}}</td>
            <td>{{currentFund.performanceScoreRank}}</td>
            <td>{{currentFund.performanceImprovementPercentage|Round:2}}</td>
            <td>{{currentFund.todayNAV|FrepNavFormat}}</td>
            <td>{{currentFund.note2}}</td>
        {% endfor %}
        </tr>
    </table>
    <p>Page {{currentPage}} of {{totalPages}}</p>
    <p>Generated on {{date|Date:""d MMMM yyyy""}}</p>
</body>
</html>";
            }
        }
        internal static string Query_11_Default_Template {
            get {
return @"<html>
<head>
    <title></title>
</head>
<body>
    <h1>Results for: {{fundCategory}}</h1>
    <table border=1>
        <tr>
            <th>Note 1</th>
            <th>Fund Name</th>
            <th>Value Research Rating as on Today</th>
            <th>Total Bond Sales in Rs (Crores) as on 3.30pm Today</th>
            <th>Fund Launch Date</th>
            <th>No. Of Days Since Launch</th>
            <th>Performance Score</th>
            <th>Performance Improvement % Rank</th>
            <th>% Performance Improvement</th>
            <th>NAV as of today</th>
            <th>Note 2</th>
        </tr>
        {% for currentFund in mutualFunds %}
        <tr>
            <td>{{currentFund.note1}}</td>
            <td>{{currentFund.fundName}}</td>
            <td>{{currentFund.valueResearchRating}}</td>
            <td>{{currentFund.totalBondSales}}</td>
            <td>{{currentFund.fundLaunchDate|Date:""d MMMM yyyy""}}</td>
            <td>{{currentFund.daysSinceLaunch}}</td>
            <td>{{currentFund.performanceScore|Round:2}}</td>
            <td>{{currentFund.performanceImprovementPercentageRank}}</td>
            <td>{{currentFund.performanceImprovementPercentage|Round:2}}</td>
            <td>{{currentFund.todayNAV|FrepNavFormat}}</td>
            <td>{{currentFund.note2}}</td>
        {% endfor %}
        </tr>
    </table>
    <p>Page {{currentPage}} of {{totalPages}}</p>
    <p>Generated on {{date|Date:""d MMMM yyyy""}}</p>
</body>
</html>";
            }
        }
        internal static string Query_12_Default_Template {
            get {
return @"<html>
<head>
    <title></title>
</head>
<body>
    <h1>Results for: {{fundCategory}}</h1>
    <table border=1>
        <tr>
            <th>Note 1</th>
            <th>Fund Name</th>
            <th>Value Research Rating as on Today</th>
            <th>Total Bond Sales in Rs (Crores) as on 3.30pm Today</th>
            <th>Fund Launch Date</th>
            <th>No. Of Days Since Launch</th>
            
            <th>Value Research Rating Rank</th>
            <th>NAV as of today</th>
            <th>Note 2</th>
        </tr>
        {% for currentFund in mutualFunds %}
        <tr>
            <td>{{currentFund.note1}}</td>
            <td>{{currentFund.fundName}}</td>
            <td>{{currentFund.valueResearchRating}}</td>
            <td>{{currentFund.totalBondSales}}</td>
            <td>{{currentFund.fundLaunchDate|Date:""d MMMM yyyy""}}</td>
            <td>{{currentFund.daysSinceLaunch}}</td>
            <td>{{currentFund.valueResearchRatingRank}}</td>
            <td>{{currentFund.todayNAV|FrepNavFormat}}</td>
            <td>{{currentFund.note2}}</td>
        {% endfor %}
        </tr>
    </table>
    <p>Page {{currentPage}} of {{totalPages}}</p>
    <p>Generated on {{date|Date:""d MMMM yyyy""}}</p>
</body>
</html>";
            }
        }
        internal static string Query_13_Default_Template {
            get {
return @"<html>
<head>
    <title></title>
</head>
<body>
    <h1>Results for: {{fundCategory}}</h1>
    <table border=1>
        <tr>
            <th>Note 1</th>
            <th>Fund Name</th>
            <th>Value Research Rating as on Today</th>
            <th>Total Bond Sales in Rs (Crores) as on 3.30pm Today</th>
            <th>Fund Launch Date</th>
            <th>No. Of Days Since Launch</th>
            <th>NAV as of today</th>
            <th>Note 2</th>
        </tr>
        {% for currentFund in mutualFunds %}
        <tr>
            <td>{{currentFund.note1}}</td>
            <td>{{currentFund.fundName}}</td>
            <td>{{currentFund.valueResearchRating}}</td>
            <td>{{currentFund.totalBondSales}}</td>
            <td>{{currentFund.fundLaunchDate|Date:""d MMMM yyyy""}}</td>
            <td>{{currentFund.daysSinceLaunch}}</td>
            <td>{{currentFund.todayNAV|FrepNavFormat}}</td>
            <td>{{currentFund.note2}}</td>
        {% endfor %}
        </tr>
    </table>
    <p>Page {{currentPage}} of {{totalPages}}</p>
    <p>Generated on {{date|Date:""d MMMM yyyy""}}</p>
</body>
</html>";
            }
        }
        internal static string Query_14_Default_Template {
            get {
return @"<html>
<head>
    <title></title>
</head>
<body>
    <h1>Results for: {{fundCategory}}</h1>
    <table border=1>
        <tr>
            <th>Note 1</th>
            <th>Fund Name</th>
            <th>Value Research Rating as on Today</th>
            <th>Total Bond Sales in Rs (Crores) as on 3.30pm Today</th>
            <th>Fund Launch Date</th>
            <th>No. Of Days Since Launch</th>
            <th>Overall Score</th>
            <th>Performance Score Rank</th>
            <th>Performance Improvement % Rank</th>
            <th>Highest Rating Rank</th>
            <th>NAV as of today</th>
            <th>Note 2</th>
        </tr>
        {% for currentFund in mutualFunds %}
        <tr>
            <td>{{currentFund.note1}}</td>
            <td>{{currentFund.fundName}}</td>
            <td>{{currentFund.valueResearchRating}}</td>
            <td>{{currentFund.totalBondSales}}</td>
            <td>{{currentFund.fundLaunchDate|Date:""d MMMM yyyy""}}</td>
            <td>{{currentFund.daysSinceLaunch}}</td>
            <td>{{currentFund.overallScore}}</td>
            <td>{{currentFund.performanceScoreRank}}</td>
            <td>{{currentFund.performanceImprovementPercentageRank}}</td>
            <td>{{currentFund.highestRatingRank}}</td>
            <td>{{currentFund.todayNAV|FrepNavFormat}}</td>
            <td>{{currentFund.note2}}</td>
        {% endfor %}
        </tr>
    </table>
    <p>Page {{currentPage}} of {{totalPages}}</p>
    <p>Generated on {{date|Date:""d MMMM yyyy""}}</p>
</body>
</html>";
            }
        }
        internal static string Query_15_Default_Template {
            get {
return @"<html>
<head>
    <title></title>
</head>
<body>
    <h1>Results for: {{fundCategory}}</h1>
    <table border=1>
        <tr>
            <th>Note 1</th>
            <th>Fund Name</th>
            <th>Value Research Rating as on Today</th>
            <th>Total Bond Sales in Rs (Crores) as on 3.30pm Today</th>
            <th>Fund Launch Date</th>
            <th>No. Of Days Since Launch</th>
            
            <th>Value Research Rating Rank</th>
            <th>NAV as of today</th>
            <th>Note 2</th>
        </tr>
        {% for currentFund in mutualFunds %}
        <tr>
            <td>{{currentFund.note1}}</td>
            <td>{{currentFund.fundName}}</td>
            <td>{{currentFund.valueResearchRating}}</td>
            <td>{{currentFund.totalBondSales}}</td>
            <td>{{currentFund.fundLaunchDate|Date:""d MMMM yyyy""}}</td>
            <td>{{currentFund.daysSinceLaunch}}</td>
            <td>{{currentFund.valueResearchRatingRank}}</td>
            <td>{{currentFund.todayNAV|FrepNavFormat}}</td>
            <td>{{currentFund.note2}}</td>
        {% endfor %}
        </tr>
    </table>
    <p>Page {{currentPage}} of {{totalPages}}</p>
    <p>Generated on {{date|Date:""d MMMM yyyy""}}</p>
</body>
</html>";
            }
        }
        internal static string Query_16_Default_Template {
            get {
return @"<html>
<head>
    <title></title>
</head>
<body>
    <h1>Results for: {{fundCategory}}</h1>
    <table border=1>
        <tr>
            <th>Note 1</th>
            <th>Fund Name</th>
            <th>Value Research Rating as on Today</th>
            <th>Total Bond Sales in Rs (Crores) as on 3.30pm Today</th>
            <th>Fund Launch Date</th>
            <th>No. Of Days Since Launch</th>
            <th>NAV as of today</th>
            <th>Note 2</th>
        </tr>
        {% for currentFund in mutualFunds %}
        <tr>
            <td>{{currentFund.note1}}</td>
            <td>{{currentFund.fundName}}</td>
            <td>{{currentFund.valueResearchRating}}</td>
            <td>{{currentFund.totalBondSales}}</td>
            <td>{{currentFund.fundLaunchDate|Date:""d MMMM yyyy""}}</td>
            <td>{{currentFund.daysSinceLaunch}}</td>
            <td>{{currentFund.todayNAV|FrepNavFormat}}</td>
            <td>{{currentFund.note2}}</td>
        {% endfor %}
        </tr>
    </table>
    <p>Page {{currentPage}} of {{totalPages}}</p>
    <p>Generated on {{date|Date:""d MMMM yyyy""}}</p>
</body>
</html>";
            }
        }
        internal static string Query_17_Default_Template {
            get {
return @"<html>
<head>
    <title></title>
</head>
<body>
    <h1>Results for: {{fundCategory}}</h1>
    <table border=1>
        <tr>
            <th>Note 1</th>
            <th>Fund Name</th>
            <th>Value Research Rating as on Today</th>
            <th>Total Bond Sales in Rs (Crores) as on 3.30pm Today</th>
            <th>Fund Launch Date</th>
            <th>No. Of Days Since Launch</th>
            <th>Overall Score</th>
            <th>Performance Score Rank</th>
            <th>Performance Improvement % Rank</th>
            <th>Highest Rating Rank</th>
            <th>NAV as of today</th>
            <th>Note 2</th>
        </tr>
        {% for currentFund in mutualFunds %}
        <tr>
            <td>{{currentFund.note1}}</td>
            <td>{{currentFund.fundName}}</td>
            <td>{{currentFund.valueResearchRating}}</td>
            <td>{{currentFund.totalBondSales}}</td>
            <td>{{currentFund.fundLaunchDate|Date:""d MMMM yyyy""}}</td>
            <td>{{currentFund.daysSinceLaunch}}</td>
            <td>{{currentFund.overallScore}}</td>
            <td>{{currentFund.performanceScoreRank}}</td>
            <td>{{currentFund.performanceImprovementPercentageRank}}</td>
            <td>{{currentFund.highestRatingRank}}</td>
            <td>{{currentFund.todayNAV|FrepNavFormat}}</td>
            <td>{{currentFund.note2}}</td>
        {% endfor %}
        </tr>
    </table>
    <p>Page {{currentPage}} of {{totalPages}}</p>
    <p>Generated on {{date|Date:""d MMMM yyyy""}}</p>
</body>
</html>";
            }
        }
        internal static string Query_18_Default_Template {
            get {
return @"<html>
<head>
    <title></title>
</head>
<body>
    <h1>Results for: {{fundCategory}}</h1>
    <table border=1>
        <tr>
            <th>Note 1</th>
            <th>Fund Name</th>
            <th>Value Research Rating as on Today</th>
            <th>Total Bond Sales in Rs (Crores) as on 3.30pm Today</th>
            <th>Performance Score Rank</th>
            <th>Yesterday NAV</th>
            <th>Today's NAV</th>
            <th>Note 2</th>
            <th>Change in NAV</th>
            <th>% Change in NAV</th>
        </tr>
        {% for currentFund in mutualFunds %}
        <tr>
            <td>{{currentFund.note1}}</td>
            <td>{{currentFund.fundName}}</td>
            <td>{{currentFund.valueResearchRating}}</td>
            <td>{{currentFund.totalBondSales}}</td>
            <td>{{currentFund.performanceScoreRank}}</td>
            <td>{{currentFund.yesterdayNAV|FrepNavFormat}}</td>
            <td>{{currentFund.todayNAV|FrepNavFormat}}</td>
            <td>{{currentFund.note2}}</td>
            <td>{{currentFund.changeInNAV|Round:0}}</td>
            <td>{{currentFund.percentageChangeInNAV|Round:2}}</td>
        {% endfor %}
        </tr>
    </table>
    <p>Page {{currentPage}} of {{totalPages}}</p>
    <p>Generated on {{date|Date:""d MMMM yyyy""}}</p>
</body>
</html>";
            }
        }
        internal static string Query_19_Default_Template {
            get {
return @"<html>
<head>
    <title></title>
</head>
<body>
    <h1>Results for: {{fundCategory}}</h1>
    <table border=1>
        <tr>
            <th>Note 1</th>
            <th>Fund Name</th>
            <th>Value Research Rating as on Today</th>
            <th>Total Bond Sales in Rs (Crores) as on 3.30pm Today</th>
            <th>Performance Score Rank</th>
            <th>Yesterday NAV</th>
            <th>Today's NAV</th>
            <th>Note 2</th>
            <th>Change in NAV</th>
            <th>% Change in NAV</th>
        </tr>
        {% for currentFund in mutualFunds %}
        <tr>
            <td>{{currentFund.note1}}</td>
            <td>{{currentFund.fundName}}</td>
            <td>{{currentFund.valueResearchRating}}</td>
            <td>{{currentFund.totalBondSales}}</td>
            <td>{{currentFund.performanceScoreRank}}</td>
            <td>{{currentFund.yesterdayNAV|FrepNavFormat}}</td>
            <td>{{currentFund.todayNAV|FrepNavFormat}}</td>
            <td>{{currentFund.note2}}</td>
            <td>{{currentFund.changeInNAV|Round:0}}</td>
            <td>{{currentFund.percentageChangeInNAV|Round:2}}</td>
        {% endfor %}
        </tr>
    </table>
    <p>Page {{currentPage}} of {{totalPages}}</p>
    <p>Generated on {{date|Date:""d MMMM yyyy""}}</p>
</body>
</html>";
            }
        }
        internal static string Query_20_Default_Template {
            get {
return @"<html>
<head>
    <title></title>
</head>
<body>
    <h1>Results for: {{fundCategory}}</h1>
    <table border=1>
        <tr>
            <th>Note 1</th>
            <th>Fund Name</th>
            <th>Value Research Rating as on Today</th>
            <th>Total Bond Sales in Rs (Crores) as on 3.30pm Today</th>
            <th>Fund Launch Date</th>
            <th>No. Of Days Since Launch</th>
            <th>Performance Score</th>
            <th>Performance Score Rank</th>
            <th>% Performance Improvement</th>
            <th>NAV as of today</th>
            <th>Note 2</th>
        </tr>
        {% for currentFund in mutualFunds %}
        <tr>
            <td>{{currentFund.note1}}</td>
            <td>{{currentFund.fundName}}</td>
            <td>{{currentFund.valueResearchRating}}</td>
            <td>{{currentFund.totalBondSales}}</td>
            <td>{{currentFund.fundLaunchDate|Date:""d MMMM yyyy""}}</td>
            <td>{{currentFund.daysSinceLaunch}}</td>
            <td>{{currentFund.performanceScore|Round:2}}</td>
            <td>{{currentFund.performanceScoreRank}}</td>
            <td>{{currentFund.performanceImprovementPercentage|Round:2}}</td>
            <td>{{currentFund.todayNAV|FrepNavFormat}}</td>
            <td>{{currentFund.note2}}</td>
        {% endfor %}
        </tr>
    </table>
    <p>Page {{currentPage}} of {{totalPages}}</p>
    <p>Generated on {{date|Date:""d MMMM yyyy""}}</p>
</body>
</html>";
            }
        }
        internal static string Query_21_Default_Template {
            get {
return @"<html>
<head>
    <title></title>
</head>
<body>
    <h1>Results for: {{fundCategory}}</h1>
    <p>example for req4: '1' = '{{fundCategory@1}}', '5' = '{{fundCategory@5}}', </p>
    <table border = 1 >
        <tr>
            <th> Note 1</th>
            <th>Fund Name</th>
            <th>Value Research Rating as on Today</th>
            <th>Total Bond Sales in Rs (Crores) as on 3.30pm Today</th>
            <th>Performance Score Rank</th>
            <th>Yesterday NAV</th>
            <th>Today's NAV</th>
            <th>Note 2</th>
            <th>Change in NAV <b>NEW</b></th>
            <th>% Change in NAV <b>NEW</b></th>
        </tr>
        {% for currentFund in mutualFunds -%}
        <tr>
            <td>{{ currentFund.note1 }}</td>
            <td>{{ currentFund.fundName }}</td>
            <td>{{ currentFund.valueResearchRating }}</td>
            <td>{{ currentFund.totalBondSales }}</td>
            <td>{{ currentFund.performanceScoreRank }}</td>
            <td>{{ currentFund.yesterdayNAV|FrepNavFormat }}</td>
            <td>{{ currentFund.todayNAV|FrepNavFormat }}</td>
            <td>{{ currentFund.note2 }}</td>
            <td>{{ currentFund.changeInNAVNew|Round:0 }}</td>
            <td>{{ currentFund.percentageChangeInNAVNew|Round:2 }}</td>
        </tr>
        {% endfor -%}
    </table>
    <p>Page {{ currentPage }} of {{ totalPages }}</p>
    <p>Generated on {{ date|Date:""d MMMM yyyy"" }}</p>
</body>
</html>";
            }
        }
        internal static string Query_22_Default_Template {
            get {
return @"<html>
<head>
    <title></title>
</head>
<body>
    <h1>Results for: {{fundCategory}}</h1>
    <table border=1>
        <tr>
            <th>Note 1</th>
            <th>Fund Name</th>
            <th>Value Research Rating as on Today</th>
            <th>Total Bond Sales in Rs (Crores) as on 3.30pm Today</th>
            <th>Fund Launch Date</th>
            <th>No. Of Days Since Launch</th>
            <th>Performance Score</th>
            <th>Performance Improvement % Rank</th>
            <th>% Performance Improvement</th>
            <th>NAV as of today</th>
            <th>Note 2</th>
            <th>Change in NAV <b>NEW</b></th>
            <th>% Change in NAV <b>NEW</b></th>
        </tr>
        {% for currentFund in mutualFunds %}
        <tr>
            <td>{{currentFund.note1}}</td>
            <td>{{currentFund.fundName}}</td>
            <td>{{currentFund.valueResearchRating}}</td>
            <td>{{currentFund.totalBondSales}}</td>
            <td>{{currentFund.fundLaunchDate|Date:""d MMMM yyyy""}}</td>
            <td>{{currentFund.daysSinceLaunch}}</td>
            <td>{{currentFund.performanceScore|Round:2}}</td>
            <td>{{currentFund.performanceImprovementPercentageRank}}</td>
            <td>{{currentFund.performanceImprovementPercentage|Round:2}}</td>
            <td>{{currentFund.todayNAV|FrepNavFormat}}</td>
            <td>{{currentFund.note2}}</td>
            <td>{{ currentFund.changeInNAVNew|Round:0 }}</td>
            <td>{{ currentFund.percentageChangeInNAVNew|Round:2 }}</td>
        {% endfor %}
        </tr>
    </table>
    <p>Page {{currentPage}} of {{totalPages}}</p>
    <p>Generated on {{date|Date:""d MMMM yyyy""}}</p>
</body>
</html>";
            }
        }
    }
}
