import React, { useState } from "react";
import { BrowserRouter as Router, Switch, Route, Link, Redirect, useLocation } from "react-router-dom";
import HomePage from "./pages/HomePage/HomePage";
import BooksPage from "./pages/BooksPage/BooksPage";
import BookCreatePage from "./pages/BooksPage/BookCreatePage";
import BookUpdatePage from "./pages/BooksPage/BookUpdatePage";
import BookDeletePage from "./pages/BooksPage/BookDeletePage";
import CategoriesPage from "./pages/CategoriesPage/CategoriesPage";
import { Container, Nav, Navbar } from "react-bootstrap";
import 'bootstrap/dist/css/bootstrap.min.css';

const App = () => {
  return (
    <Container>
      <Router>
        <Navbar bg="dark" variant="dark" className="mb-5">
          <Nav className="me-auto">
            <Nav.Link href="/">Home</Nav.Link>
            <Nav.Link href="/books">Book</Nav.Link>
            <Nav.Link href="/categories">Category</Nav.Link>
          </Nav>
        </Navbar>
        <Switch>
          <Route path="/" exact>
            <HomePage />
          </Route>
          <Route path="/books" exact>
            <BooksPage />
          </Route>
          <Route path="/categories" exact>
            <CategoriesPage />
          </Route>
          <Route path="/book/create" exact>
            <BookCreatePage />
          </Route>
          <Route path="/book/update/:id" exact>
            <BookUpdatePage />
          </Route>
          <Route path="/book/delete/:id" exact>
            <BookDeletePage />
          </Route>
        </Switch>
      </Router>

    </Container>
  );
}

export default App;
