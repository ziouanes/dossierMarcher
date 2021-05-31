@extends('layouts.master')
@section('content')


    <div class="layer"></div>
    <!-- Mobile menu overlay mask -->

    {{-- <div id="preloader">
        <div data-loader="circle-side"></div>
    </div> --}}
    <!-- End Preload -->


    <!-- SubHeader =============================================== -->
    <section class="parallax_window_in" data-parallax="scroll" data-image-src="img/sub_header_about.jpg"
        data-natural-width="1400" data-natural-height="470">
        <div id="sub_content_in">
            <div id="animate_intro">
                <h1>Practical Information</h1>
            </div>
        </div>
    </section>
    <!-- End section -->
    <!-- End SubHeader ============================================ -->

    <section class="wrapper">
        <div class="divider_border"></div>
        <div class="container">
            <div class="row">
                <div class="col-md-4 col-sm-6 wow fadeIn animated" data-wow-delay="0.2s">
                    <div class="img_wrapper">
                        <div class="img_container">
                            <a href="detail-page.html">
                                <img src="img/tour_list_6.jpg" width="800" height="533" class="img-responsive" alt="">
                                <div class="short_info">
                                    <h3>Our Grading System</h3>
                                    <p>
                                        In this section you will read the definitions we use for our ratings. We hope that
                                        this will help you choose the right tour for you.
                                    </p>
                                </div>
                            </a>
                        </div>
                    </div>
                    <!-- End img_wrapper -->
                </div>
                <div class="col-md-4 col-sm-6 wow fadeIn animated" data-wow-delay="0.2s">
                    <div class="img_wrapper">
                        <div class="img_container">
                            <a href="detail-page.html">
                                <img src="img/tour_list_6.jpg" width="800" height="533" class="img-responsive" alt="">
                                <div class="short_info">
                                    <h3>Health, Fitness and Safety</h3>
                                    <p>
                                        Our top priority at High Atlas Hiking is the safety of our clients, and we take
                                        several steps on each tour to maintain a level of precaution as needed.
                                    </p>
                                </div>
                            </a>
                        </div>
                    </div>
                    <!-- End img_wrapper -->
                </div>
                <!-- End col -->
                <div class="col-md-4 col-sm-6 wow fadeIn animated" data-wow-delay="0.2s">
                    <div class="img_wrapper">
                        <div class="img_container">
                            <a href="detail-page.html">
                                <img src="img/tour_list_6.jpg" width="800" height="533" class="img-responsive" alt="">
                                <div class="short_info">
                                    <h3>What to bring | Equipment List</h3>
                                    <p>
                                        Equipment needed can vary greatly from season to season as well as the length of
                                        your hike. The following list can be used as a guideline for our trekking and hiking
                                        tours in the high Atlas
                                    </p>
                                </div>
                            </a>
                        </div>
                    </div>
                    <!-- End img_wrapper -->
                </div>
                <!-- End col -->
                <div class="col-md-4 col-sm-6 wow fadeIn animated" data-wow-delay="0.2s">
                    <div class="img_wrapper">
                        <div class="img_container">
                            <a href="detail-page.html">
                                <img src="img/tour_list_6.jpg" width="800" height="533" class="img-responsive" alt="">
                                <div class="short_info">
                                    <h3>What to bring for Toukal winter climb</h3>
                                    <p>
                                        Here is a quick list of all the gear that you need to pack for Mount Toubka climb in
                                        winter. Keep in mind that there are limits on how much your duffel bag can weigh
                                        because the weight restrictions on international and domestic flights are usually
                                        around 20 kg.
                                    </p>
                                </div>
                            </a>
                        </div>
                    </div>
                    <!-- End img_wrapper -->
                </div>
                <!-- End col -->
                <div class="col-md-4 col-sm-6 wow fadeIn animated" data-wow-delay="0.2s">
                    <div class="img_wrapper">
                        <div class="img_container">
                            <a href="detail-page.html">
                                <img src="img/tour_list_6.jpg" width="800" height="533" class="img-responsive" alt="">
                                <div class="short_info">
                                    <h3>Meals on trek</h3>
                                    <p>
                                        As a general rule, the food you eat during your treks will be dominated by fresh
                                        salads, vegetables and either couscous or pasta, followed by fresh seasonal fruits
                                        and accompanied by small breads, and sweet mint tea.
                                    </p>
                                </div>
                            </a>
                        </div>
                    </div>
                    <!-- End img_wrapper -->
                </div>
                <!-- End col -->
            </div>
            <!-- End row -->
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
