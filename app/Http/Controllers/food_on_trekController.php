<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class food_on_trekController extends Controller
{
    public function index()
    {


        return view('food_on_trek');
    }
}
