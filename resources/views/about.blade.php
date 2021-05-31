@extends('layouts.master')
@section('content')


    <!-- SubHeader =============================================== -->
    <section class="parallax_window_in" data-parallax="scroll"
        data-image-src="{{ url('assets/img/2_day_toubkal_trek.jpg') }}" data-natural-width="1400"
        data-natural-height="470">
        <div id="sub_content_in">
            <div id="animate_intro">
                <h1>About High Atlas Hiking</h1>
                <p>"I enjoyed an amazing trek in the atlas mountain organised by High Atlas Trekking which was very easy to
                    use..."</p>
            </div>
        </div>
    </section>
    <!-- End section -->
    <!-- End SubHeader ============================================ -->

    <section class="wrapper">
        <div class="divider_border"></div>

        <div class="container">
            <div class="main_title">
                <h2>Some <span>High Atlas Hiking</span> info</h2>
                <p>Our extensive knowledge and focus on safety have made us the top choice for thousands of happy customers
                    from all over the world</p>
            </div>

            <div class="row">
                <div class="col-sm-6">
                    <h3>The Company</h3>
                    <p>High Atlas Hiking has been organizing walking holidays in Morocco for over 15 years now. The business
                        was originally set up to target French speaking countries, and from 2014 we have reinvented,
                        rejuvenated and reinvigorated it with lots of new ideas, new routes and new members of the team! We
                        strive to expand, learn new things and provide new solutions - we don’t cease to learn.</p>
                    <p>We specialize in organizing great walks off the usual beaten track; but more than that, we also pride
                        ourselves on our choice of traditional accommodation, and the care we take when organizing your
                        itinerary as a whole. We believe that a truly fabulous holiday is the sum of its parts - the walks,
                        your guide, where you stay, the guest house we choose, where and what you eat and even the view when
                        you stop for your picnic.... and we do our very best to make each of these exceptional!</p>
                    <h4>Why hike with us?</h4>
                    <p>We're all long-standing, full-time residents of the Atlas - we know it well, and we know what makes
                        it special. We also know how to combine our expertise with the best walks and the highest levels of
                        personal service. The result is an exceptional holiday with an insight into the real High Atlas…
                        Thanks to the fact that we’ve shown Morocco to thousands of people from all over the world we know
                        what to pay attention to. You don’t have to worry - we’ll organize everything for you and make sure
                        to give you one of a kind adventure!</p>
                </div>
                <div class="col-sm-6">
                    <p class="advertise"><img src="{{ URL::asset('assets/img/trip-advisor.jpg') }}" alt=""
                            class="img-responsive">
                    </p>
                </div>
            </div>
            <!-- End row -->
        </div>
        <!-- End container -->
    </section>
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
