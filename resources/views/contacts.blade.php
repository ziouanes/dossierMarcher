@extends('layouts.master')
@section('content')


    <div class="layer"></div>
    <!-- Mobile menu overlay mask -->

    {{-- <div id="preloader">
        <div data-loader="circle-side"></div>
    </div> --}}
    <!-- End Preload -->


    <!-- SubHeader =============================================== -->
    <section class="parallax_window_in" data-parallax="scroll"
        data-image-src="{{ URL::asset('assets/img/2_day_toubkal_trek.jpg') }}" data-natural-width="1400"
        data-natural-height="470">
        <div id="sub_content_in">
            <div id="animate_intro">
                <h1>Contact Us</h1>
            </div>
        </div>
    </section>
    <!-- End section -->
    <!-- End SubHeader ============================================ -->

    <section class="wrapper">
        <div class="divider_border"></div>
        <div class="container">
            <div class="row">

                <aside class="col-md-3">
                    <div class="box_style_2">
                        <h4 class="nomargin_top">Contacts info</h4>
                        <p>
                            Dr Imlil, Asni, Alhouz, Marrakech, Morocco
                            <br> + 212 (0) 694038831
                            <br>
                            <a href="#">contact@highatlashiking.com</a>
                        </p>
                        <h5>Get directions</h5>
                        <form action="http://maps.google.com/maps" method="get" target="_blank">
                            <div class="form-group">
                                <input type="text" name="saddr" placeholder="Enter your location"
                                    class="form-control styled">
                                <input type="hidden" name="daddr" value="Imlil Morocco">
                                <!-- Write here your end point -->
                            </div>
                            <input type="submit" value="Get directions" class="btn_1 add_bottom_15">
                        </form>
                        <hr class="styled">
                        <h4>Departmens</h4>
                        <ul class="contacts_info">
                            <li>Administration
                                <br>
                                <a href="tel://+212659924994">+212(0)659924994</a>
                                <br><a href="tel://003823932342">mohamed@highatlashiking.com</a>
                                <br>
                                <small>Monday to Friday 9am - 7pm</small>
                            </li>
                            <li>General questions
                                <br>
                                <a href="tel://003823932342">+ 212 (0) 694038831 </a>
                                <br><a href="tel://003823932342">contact@highatlashiking.com</a>
                                </p>
                            </li>
                        </ul>
                    </div>
                </aside>
                <!--End aside -->

                <div class="col-md-9">
                    <h3>Send us a message</h3>
                    <p>
                        Any questions? Please fill out the form below and we will get back to you within 24 hours.
                    </p>
                    <div>
                        <div id="message-contact"></div>
                        <form method="post" action="assets/contact.php" id="contactform">
                            <div class="row">
                                <div class="col-md-6 col-sm-6">
                                    <div class="form-group">
                                        <label>First name</label>
                                        <input type="text" class="form-control styled" id="name_contact" name="name_contact"
                                            placeholder="Jhon">
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <div class="form-group">
                                        <label>Last name</label>
                                        <input type="text" class="form-control styled" id="lastname_contact"
                                            name="lastname_contact" placeholder="Doe">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-sm-6">
                                    <div class="form-group">
                                        <label>Email:</label>
                                        <input type="email" id="email_contact" name="email_contact"
                                            class="form-control styled" placeholder="jhon@email.com">
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <div class="form-group">
                                        <label>Phone number:</label>
                                        <input type="text" id="phone_contact" name="phone_contact"
                                            class="form-control styled" placeholder="00 44 5435435">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>Your message:</label>
                                        <textarea rows="5" id="message_contact" name="message_contact"
                                            class="form-control styled" style="height:100px;"
                                            placeholder="Hello world!"></textarea>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Are you human? 3 + 1 =</label>
                                        <input type="text" id="verify_contact" class=" form-control styled"
                                            placeholder=" 3 + 1 =">
                                    </div>
                                    <p>
                                        <input type="submit" value="Submit" class="btn_1" id="submit-contact">
                                    </p>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
                <!-- End col lg 9 -->
            </div>
            <!-- End row -->
        </div>
        <!-- End container -->
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
