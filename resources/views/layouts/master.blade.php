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
<!--------------------------->
    @yield('content')

<!--------------------------->

     @include('layouts.main-footer')

	<!-- End footer -->
	<div id="toTop"></div>
	<!-- Back to top button -->

	<!-- Search Menu -->
	<div class="search-overlay-menu">
		<span class="search-overlay-close"><i class="icon_close"></i></span>
		<form role="search" id="searchform" method="get">
			<input value="" name="q" type="search" placeholder="Search..." />
			<button type="submit"><i class="icon-search-6"></i>
			</button>
		</form>
	</div>
	<!-- End Search Menu -->


     @include('layouts.footer-scripts')


</body>

</html>

<script>
    setInterval(function() {
        $("#notifications_count").load(window.location.href + " #notifications_count");
        $("#unreadNotifications").load(window.location.href + " #unreadNotifications");
    }, 5000);

</script>