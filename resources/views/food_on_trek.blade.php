@extends('layouts.master')
@section('content')


    <!-- SubHeader =============================================== -->
    <section class="parallax_window_in" data-parallax="scroll" data-image-src="img/sub_header_about.jpg"
        data-natural-width="1400" data-natural-height="470">
        <div id="sub_content_in">
            <div id="animate_intro">
                <h1>High Atlas Hiking - Meals on trek</h1>
            </div>
        </div>
    </section>
    <!-- End section -->
    <!-- End SubHeader ============================================ -->

    <section class="wrapper">
        <div class="divider_border"></div>

        <div class="container">
            <div class="col-md-8 col-md-offset-2">
                <div>
                    <div class="row">
                        <div class="col-md-12">
                            <p>As a general rule, the food you eat during your treks will be dominated by fresh salads,
                                vegetables and either couscous or pasta, followed by fresh seasonal fruits and accompanied
                                by small breads, and sweet mint tea. The food is all freshly prepared and is very healthy
                                and nutritious. It is often worth bringing a small supply of your own favourite high-energy
                                snacks to eat during the trek if you find your energy decreasing. Things such as jelly and
                                energy bars or gels can be a useful backup in this case. As can dried fruits and nuts.</p>
                            <hr>
                            <h2 class="nomargin_top">
                                <font color="O,32,96">Breakfast</font>
                            </h2>
                            <p>Breakfast is in Moroccan style with semi-flat bread, jams, honey, processed cheese and
                                butter. It comes with sweet, black mint tea or coffee. You will also sometimes have fried or
                                boiled eggs.</p>
                            <hr>
                            <h2 class="nomargin_top">
                                <font color="O,32,96">Lunch</font>
                            </h2>
                            <p>During our trek we will stop for around 30-40 minutes and have a good lunch. Our cook and
                                muleteers will go on ahead of us and set up 'camp' to make our lunch. This is mostly in an
                                attractive spot on the trail. The exact time of the meal depends on our speed covering the
                                ground to the position previously agreed with our cook and muleteers. Therefore, if we are a
                                slower group it may be 2 pm before we stop.<br>Lunch is usually mint-tea with bread and a
                                huge platter of finely chopped salad such as tomato, pepper and onion along with sweetcorn,
                                olives, sardines, beans and preserved meats. We will often have delicious local oranges as
                                well.</p>
                            <div class="row magnific-gallery">
                                <div class="col-md-6">
                                    <a href="img/gallery/lunch.jpg" title="picnic lunch"><img src="img/gallery/lunch.jpg"
                                            alt="" class="img-responsive">
                                    </a>
                                </div>
                            </div>
                            <hr>
                            <h2 class="nomargin_top">
                                <font color="O,32,96">Dinner</font>
                            </h2>
                            <p>Dinner may be various but a typical meal would be Moroccan-style soup and bread followed by a
                                chicken or vegetable tagine and couscous, rice or pasta. You will also have seasonal fruit
                                for desserts such as oranges, watermelon or cantaloupe.</p>
                        </div>
                    </div>
                    <div class="row magnific-gallery">
                        <div class="col-md-6">
                            <a href="img/gallery/camping.jpg" title="Dinner when camping"><img src="img/gallery/camping.jpg"
                                    alt="" class="img-responsive">
                            </a>
                        </div>
                        <div class="col-md-6">
                            <a href="img/gallery/dinner.jpg" title="Dinner at Berber house"><img
                                    src="img/gallery/dinner.jpg" alt="" class="img-responsive">
                            </a>
                        </div>
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
