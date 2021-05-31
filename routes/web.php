<?php

use Illuminate\Support\Facades\Route;

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| contains the "web" middleware group. Now create something great!
|
*/

Route::get('/', function () {


    return view('home');
});
Route::get('/home', 'HomeController@index')->name('home');


Route::get('/all_hikes', 'PostController@index')->name('post.all_hikes');

Route::get('/contacts', 'contacts@index')->name('post.contacts');
Route::get('/about', 'aboutController@index')->name('post.about');
Route::get('/food_on_trek', 'food_on_trekController@index')->name('post.food_on_trek');
Route::get('/health_and_safety', 'health_and_safetyController@index')->name('post.health_and_safety');
Route::get('/what_to_bring', 'what_to_bringController@index')->name('post.what_to_bring');
Route::get('/our_grading', 'our_gradingController@index')->name('post.our_grading');
Route::get('/kit_list_for_toubkal_climb', 'kit_listController@index')->name('post.kit_list');
