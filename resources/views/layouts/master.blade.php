<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<meta name="description" content="See the splendors of the High Atlas with our experienced, local guides. From easy day hikes to Mt. Toubkal treks, we have an adventure for you!">
    @include('layouts.head')
</head>

<body >
    
	<div class="layer"></div>
	<!-- Mobile menu overlay mask -->

{{--<div id="preloader">
		<div data-loader="circle-side"></div>
	</div>--}}
   
    <!-- /Loader -->
    @include('layouts.main-header')
    <!-- main-content -->
 {{--  <div class="main-content app-content">
        @include('layouts.main-header')
        <!-- container -->
        <div class="container-fluid">
           @yield('page-header')
            @yield('content')
            @include('layouts.sidebar')
            @include('layouts.models')
            @include('layouts.footer')
            --}}
            @include('layouts.main-footer')

     @include('layouts.footer-scripts')
</body>

</html>

<script>
    setInterval(function() {
        $("#notifications_count").load(window.location.href + " #notifications_count");
        $("#unreadNotifications").load(window.location.href + " #unreadNotifications");
    }, 5000);

</script>