<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="report.aspx.cs" Inherits="EasyReportingTool.report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/jquery1_11_3.js" type="text/javascript"></script>
                <script src="js/underscore.js" type="text/javascript"></script>
        <script src="js/backbone.js" type="text/javascript"></script>

        <script src="js/backgrid.js" type="text/javascript"></script>
            <script src="js/backbonepaginator.js" type="text/javascript"></script>
    <script src="js/backgridpaginator.js" type="text/javascript"></script>
        <link href="css/backgrid.min.css" rel="stylesheet" type="text/css" />
    <script src="js/backgridfilter.js" type="text/javascript"></script>
    <link href="css/backgridfilter.css" rel="stylesheet" type="text/css" />
    <link href="css/pagination.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript">


            $(document).ready(function () {




                var Query = Backbone.Model.extend({});

                /* var QueryResult = Backbone.Collection.extend({
                model: Query,
                url: "getdata.aspx"
                });*/
                /*
                var QueryResult = Backbone.PageableCollection.extend({
                model: Query,
                url: "getdata.aspx",
                state: {
                pageSize: 15
                },
                mode: "client" // data entirely on the client side
                });


                var queryResult = new QueryResult();
                var queryColumns = {};
                jQuery.ajax({
                url: "getcolumns.aspx",
                success: function (data) {
                queryColumns = JSON.parse(data);
                },
                async: false
                });


                // Initialize a new Grid instance
                var grid = new Backgrid.Grid({
                columns: queryColumns,
                collection: queryResult
                });

                // Set up a grid to use the pageable collection
                var pageableGrid = new Backgrid.Grid({
                columns:queryColumns,
                collection: QueryResult
                });



                // Render the grid and attach the root to your HTML document
                $("#report").append(pageableGrid.render().el);

                var paginator = new Backgrid.Extension.Paginator({
                collection: QueryResult
                });

                $("#report").after(paginator.render().el);

                var filter = new Backgrid.Extension.ClientSideFilter({
                collection: pageableTerritories,
                fields: ['Partner']
                });



                $("#report").before(filter.render().el);


                // Fetch some countries from the url
                queryResult.fetch({ reset: true });
                */



                var queryColumns = {};
                jQuery.ajax({
                    url: "getcolumns.aspx",
                    success: function (data) {
                        queryColumns = JSON.parse(data);
                    },
                    async: false
                });

                var Territory = Backbone.Model.extend({});




                var PageableTerritories = Backbone.PageableCollection.extend({
                    model: Territory,
                    url: "getdata.aspx",
                    state: {
                        pageSize: 15
                    },
                    mode: "client" // page entirely on the client side
                });

                var pageableTerritories = new PageableTerritories();

                // Set up a grid to use the pageable collection
                var pageableGrid = new Backgrid.Grid({
                    columns: queryColumns,
                    collection: pageableTerritories
                });

                // Render the grid
                var $example2 = $("#report");
                $example2.append(pageableGrid.render().el)

                // Initialize the paginator
                var paginator = new Backgrid.Extension.Paginator({
                    collection: pageableTerritories
                });

                // Render the paginator
                $example2.after(paginator.render().el);

                filterColumns = [];
                for (var x = 0; x < queryColumns.length; x++) {
                    filterColumns.push(queryColumns[x].name);
                }

                // Initialize a client-side filter to filter on the client
                // mode pageable collection's cache.
                var filter = new Backgrid.Extension.ClientSideFilter({
                    collection: pageableTerritories,
                    fields: filterColumns
                });

                // Render the filter
                $example2.before(filter.render().el);

                // Add some space to the filter and move it to the right
                $(filter.el).css({ float: "right", marginTop: "-50px" });

                // Fetch some data
                pageableTerritories.fetch({ reset: true });

            });
            
        </script>
</head>
<body>
    <form id="form1" runat="server" >
    <br/><br/><br/><br/>
    <div id="report" >
    
    </div>
    </form>
</body>
</html>
