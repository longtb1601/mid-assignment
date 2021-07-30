import React, { useEffect, useState } from 'react';
import { BrowserRouter as Router, Switch, Route, Link, Redirect, useLocation } from "react-router-dom";
import axios from 'axios';

const BooksPage = () => {
    const [isLoading, setIsLoading] = useState(true);
    const [books, setBooks] = useState([]);

    useEffect(() => {
        axios.get('https://localhost:5001/api/Book').then(response => {
            setIsLoading(false);
            setBooks(response.data);
        })
    }, []);

    if (isLoading) return <h1>Loading...</h1>

    return (
        <div>
            <div className="d-flex justify-content-between align-items-center">
                    <h1>List books</h1>
                    <Link to={`/book/create`} className="btn btn-primary">Create new book</Link>
            </div>
            <table className="table table-bordered">
                <thead>
                    <tr>
                        <th className="text-center" style={{width: '10%'}}>ID</th>
                        <th className="text-center">Name</th>
                        <th className="text-center" style={{width: '20%'}}>Action</th>
                    </tr>
                </thead>
                <tbody>
                    {books.map(
                        book => (
                            <tr key={book.id}>
                                <td className="text-center">{book.id}</td>
                                <td>{book.name}</td>
                                <td className="text-center">
                                    <Link to={`/book/update/${book.id}`} key={book.id} className="btn btn-warning">
                                        Update
                                    </Link>
                                    <span> | </span> 
                                    <Link to={`/book/delete/${book.id}`} key={book.id} className="btn btn-danger">
                                        Delete
                                    </Link>
                                </td>
                            </tr>
                        )
                    )}
                </tbody>
            </table>
        </div>
    );
}

export default BooksPage;