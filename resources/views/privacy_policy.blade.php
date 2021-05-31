@extends('layouts.master')
@section('content')


    <div class="layer"></div>
    <!-- Mobile menu overlay mask -->

    {{-- <div id="preloader">
        <div data-loader="circle-side"></div>
    </div> --}}
    <!-- End Preload -->


    <!-- SubHeader =============================================== -->
    <!-- SubHeader =============================================== -->
    <section class="parallax_window_in" data-parallax="scroll" data-image-src="img/2_day_toubkal_trek.jpg"
        data-natural-width="1400" data-natural-height="470">
        <div id="sub_content_in">
            <div id="animate_intro">
                <h1>Privacy Policy</h1>
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
                        <p>This privacy policy has been compiled to better serve those who are concerned with how their
                            'Personally Identifiable Information' (PII) is being used online. PII, as described in US
                            privacy law and information security, is information that can be used on its own or with other
                            information to identify, contact, or locate a single person, or to identify an individual in
                            context. Please read our privacy policy carefully to get a clear understanding of how we
                            collect, use, protect or otherwise handle your Personally Identifiable Information in accordance
                            with our website.</p>
                        <hr>
                        <h4 class="nomargin_top">What personal information do we collect from the people that visit our
                            website?</h4>
                        <p>When registering with us, we may collect the following information from you such as:</p>
                        <ul class="list_ok">
                            <li>Full name</li>
                            <li>Contact information, including e-mail address or phone number</li>
                            <li>Other information relevant to surveys/promotional offers</li>
                        </ul>
                        <hr>
                        <h4 class="nomargin_top">How do we use your information?</h4>
                        <p>We do not use vulnerability scanning and/or scanning to PCI standards. We only use your personal
                            information in order to provide you with the travel offers & promotion from our site and provide
                            our members with outstanding service as we continue to improve our own content and services.</p>
                        <hr>
                        <h4 class="nomargin_top">Do we use 'cookies'?</h4>
                        <p>We do not use cookies for tracking purposes</p>
                        <p>You can choose to have your computer warn you each time a cookie is being sent, or you can choose
                            to turn off all cookies. You do this through your browser settings. Since browser is a little
                            different, look at your browser's Help Menu to learn the correct way to modify your cookies.</p>
                        <p>If you turn cookies off, some of the features that make your site experience more efficient may
                            not function properly. That make your site experience more efficient and may not function
                            properly.</p>
                        <hr>
                        <h4 class="nomargin_top">Third-party disclosure</h4>
                        <p>We do not sell, trade, or otherwise transfer to outside parties your Personally Identifiable
                            Information.</p>
                        <hr>
                        <h4 class="nomargin_top">Third-party links</h4>
                        <p>This privacy policy only covers our website, at highatlashiking.com. Our website may contain
                            links to other websites. Note that we do not have any control over other website once you leave
                            our website and we are not responsible for the protection and privacy of any information which
                            you provide while visiting such sites. Other sites may have privacy policies that differ from
                            ours.</p>
                        <hr>
                        <h4 class="nomargin_top">Our website uses remarketing.</h4>
                        <p> Remarketing involves:</p>
                        <ul class="list_ok">
                            <li>Third party vendors, including Google, show our ads on sites on the internet.</li>
                            <li>Third party vendors, including Google, use cookies to serve ads based on a user’s prior
                                visits to our website.</li>
                        </ul>
                        <p>Users may opt out of Google’s use of cookies by visiting the<a
                                href="https://policies.google.com/technologies/ads" target="_blank"> Google advertising
                                opt-out page.</a></p>
                        <hr>
                        <h4 class="nomargin_top">If at any time you would like to unsubscribe from receiving future emails
                        </h4>
                        <p>Follow the instructions at the bottom of each email. And we will promptly remove you from ALL
                            correspondence.</p>
                        <hr>
                        <h4 class="nomargin_top">Contacting Us</h4>
                        <p>If there are any questions regarding this privacy policy, you may contact us using the following
                            emil: contact@highatlashiking.com</p>
                        <p>Last Edited on 2020-04-10 </p>
                        <hr>
                    </div>
                </div>
            </div>
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
