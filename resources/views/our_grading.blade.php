@extends('layouts.master')
@section('content')


    <!-- SubHeader =============================================== -->
    <section class="parallax_window_in" data-parallax="scroll" data-image-src="img/2_day_toubkal_trek.jpg"
        data-natural-width="1400" data-natural-height="470">
        <div id="sub_content_in">
            <div id="animate_intro">
                <h1>Our grading System</h1>
            </div>
        </div>
    </section>
    <!-- End section -->
    <!-- End SubHeader ============================================ -->

    <section class="wrapper">
        <div class="divider_border"></div>

        <div class="container">
            <div class="col-md-8 col-md-offset-2">
                <div class="row">
                    <div class="col-md-12">
                        <p>In order to keep you mentally ready for the difficulty of the walk to be taken, we have a simple
                            system which allows you to assess the upcoming walk.</p>
                        <hr>
                        <h2 class="nomargin_top">
                            <font color="O,32,96">Gentle Treks</font>
                        </h2>
                        <p>If you are able to walk just fine and are healthy enough to stroll around, then the gentle treks
                            are just the perfect treks for you. Your guide will be discussing the different sections of the
                            trek with you so that you can plan on how to enjoy and manage the complete trekking experience.
                            Typically 2-5hrs per day.</p>
                        <hr>
                        <h2 class="nomargin_top">
                            <font color="O,32,96">Moderate Treks</font>
                        </h2>
                        <p>Our next level of trekking is categorized as moderate. To be able to enjoy these trekking
                            adventures, you need to have a regular practice of walks. Long walks can be more helpful. During
                            the adventure, it is expected that you will come across some inclined terrains to walk over but
                            our guides will be there to assist you in crossing the steep climbs. Typically 4-6 hrs walking
                            per day.</p>
                        <hr>
                        <h2 class="nomargin_top">
                            <font color="O,32,96">Challenging Treks</font>
                        </h2>
                        <p>If you are a regular enthusiast for hiking and are used to go on long adventures consisting of
                            many days, then you are more than welcome to join our adventures in this category. We will be
                            experiencing different weathers and will have only the basic facilities at some points. You
                            being in your best physical form with good stamina will be important for such trekking
                            adventures as he trekking height can more than 3000 feet. Typically 4-9 hrs walking per day with
                            occasional longer days (10-12h).</p>
                        <hr>
                        <h2 class="nomargin_top">
                            <font color="O,32,96">Demanding Treks</font>
                        </h2>
                        <p>This is our toughest category for trekking and to be able to go on such trips we would recommend
                            you to be a professional trekker and experienced trekking on harsh terrains. Your best health
                            status is a must and we would recommend you to be at the peak of your stamina in order to
                            participate in such trekking adventures because some treks are at an altitude of more than three
                            thousand feet.Long days of 6 - 9 hrs walking. Occasional longer days (10-12h).</p>
                    </div>
                </div>
            </div>
        </div>
        <!-- End container -->
    </section>
    <!-- End section -->
@endsection
@section('js')
    <!--Internal  Chart.bundle js -->
    <script src="{{ URL::asset('assets/plugins/jquery.selectbox-0.2.js') }}"></script>
    <script src="{{ URL::asset('assets/plugins/functions.js"') }}"></script>
    <script src="{{ URL::asset('assets/plugins/common_scripts_min.js') }}"></script>


    <script>
        $(".selectbox").selectbox();

    </script>
@endsection
