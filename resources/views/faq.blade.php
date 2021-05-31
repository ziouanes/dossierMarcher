@extends('layouts.master')
@section('content')


    <div class="layer"></div>
    <!-- Mobile menu overlay mask -->

    {{-- <div id="preloader">
        <div data-loader="circle-side"></div>
    </div> --}}
    <!-- End Preload -->


    <!-- SubHeader =============================================== -->
    <section class="parallax_window_in" data-parallax="scroll" data-image-src="img/2_day_toubkal_trek.jpg"
        data-natural-width="1400" data-natural-height="470">
        <div id="sub_content_in">
            <div id="animate_intro">
                <h1>Frequently Asked Questions</h1>
            </div>
        </div>
    </section>
    <!-- End section -->
    <!-- End SubHeader ============================================ -->

    <section class="wrapper">
        <div class="divider_border"></div>

        <div class="container">

            <div class="main_title">
                <p>The following are questions we are asked most frequently. Click to expand each question</p>
            </div>

            <div id="bg_profile">
                <div class="row">
                    <div class="col-md-8 col-md-offset-2">
                        <div class="panel-group" id="accordion">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion"
                                            href="#collapse1">Do you also organize a shared group tours or only a privet
                                            guided hikes?<i class="indicator icon_minus_alt2 pull-right"></i></a>
                                    </h4>
                                </div>
                                <div id="collapse1" class="panel-collapse collapse in">
                                    <div class="panel-body">
                                        Yes, we do sometimes arrange a shared small group hike, If you are intrested please
                                        contact us as there is often the opportunity to join a group.
                                    </div>
                                </div>
                            </div>
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion"
                                            href="#collapse2">Do you only give tours in English?<i
                                                class="indicator icon_plus_alt2 pull-right"></i></a>
                                    </h4>
                                </div>
                                <div id="collapse2" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        We are proud to say that we have an incredible team with a wide array of languages.
                                        In total, we can offer tours in English, French and Spanish . We also have a Russian
                                        interpreter that can come along and translate for us. Please indicate your language
                                        preference upon booking.
                                    </div>
                                </div>
                            </div>
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion"
                                            href="#collapse3">You mention that the itineraries are flexible. What are some
                                            other things that we can do?<i
                                                class="indicator icon_plus_alt2 pull-right"></i></a>
                                    </h4>
                                </div>
                                <div id="collapse3" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        We know The High Atlas like the backs of their hands! If you are interested in
                                        seeing certain things — like art, Bird watching ... — just speak up. We can put
                                        together something special just for you.
                                    </div>
                                </div>
                            </div>
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion"
                                            href="#collapse4">will you be able to accommodate dietary restrictions?<i
                                                class="indicator icon_plus_alt2 pull-right"></i></a>
                                    </h4>
                                </div>
                                <div id="collapse4" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        We like to feature truly Moroccan food on our tours to give our guests a good feel
                                        for the country in all aspects. However, if you have a dietary restriction, please
                                        let us know at the beginning of the tour and we will do our best to accommodate you.
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--end col -->
                </div>
                <!-- End row -->
            </div>
            <!-- End bg_profile -->
        </div>
        <!-- End container -->
        <div class="bannery">
            <div class="main_title_3">
                <h2>STILL HAVE SOME QUESTIONS?</h2>
                <h3>LET’S GET IN TOUCH!</h3>
                <a href="contacts" class="leila_3">Contact Us Now</a>
            </div>
        </div>
    </section>
    <!-- End section -->
    <!-- end container -->

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
