import React, { useState, useEffect } from "react";
import axios from "axios";
import { Formik } from "formik";
import { Form, Button, Row, Col } from "react-bootstrap";
import { BrowserRouter as Router, Switch, Route, Link, useParams } from "react-router-dom";

const initialValues = { name: "", categoryId: "" };

const validateValues = (values) => {
    const errors = {};
    if (!values.name) {
        errors.name = "Title of book is required";
    }

    if (!(values.categoryId > 0)) {
        errors.categoryId = "You must choose category";
    }
   
    return errors;
};

const BookUpdatePage = () => {
    const {id} = useParams();
    const [categories, setCategories] = useState([]);
    const [book, setBook] = useState([]);
    const [isLoading, setIsLoading] = useState(true);

    useEffect(() => {
        axios.all([
            axios.get('https://localhost:5001/api/Category'), 
            axios.get(`https://localhost:5001/api/Book/${id}`)
          ]).then(axios.spread((responseCat, responseBook) => {
            setIsLoading(false);
            setCategories(responseCat.data);
            setBook(responseBook.data);
          }));
    }, [id]);

    const onSubmit = (values, { setSubmitting }) => {
        axios.put(`https://localhost:5001/api/Book/${id}`, {
            Name: values.name,
            CategoryId: values.categoryId,
        })
            .then((response) => {
                setSubmitting(false);
            });
    };

    if (isLoading) return <h1>Loading...</h1>

    return (
        <div className="login-form container">
            <div className="text-center">
                <h3>Create new book</h3>
            </div>
            <Formik
                initialValues={initialValues}
                validate={validateValues}
                onSubmit={onSubmit}
            >
                {({
                    handleSubmit,
                    handleChange,
                    handleBlur,
                    values,
                    touched,
                    isValid,
                    errors,
                    /* and other goodies */
                }) => (
                    <Form noValidate onSubmit={handleSubmit}>
                        <Row className="text-center">
                            <Col md={4}></Col>
                            <Col md={4}>
                                <Form.Group controlId="validationFormik102" className="mb-3">
                                    <Form.Control
                                        placeholder="Title of book"
                                        type="text"
                                        name="name"
                                        value={values.name = book.name}
                                        onChange={handleChange}
                                        onBlur={handleBlur}
                                        isInvalid={errors.name}
                                        isValid={!errors.name}
                                    />
                                    <Form.Control.Feedback type="valid">
                                        Look good
                                    </Form.Control.Feedback>
                                    <Form.Control.Feedback type="invalid" className="d-block">
                                        {errors.name}
                                    </Form.Control.Feedback>
                                </Form.Group>

                                <Form.Group className="mb-3" controlId="formBasicPassword">
                                    <Form.Select aria-label="" name="categoryId"
                                        value={values.categoryId = book.categoryId}
                                        onChange={handleChange}
                                        onBlur={handleBlur} 
                                        isInvalid={errors.categoryId}
                                        isValid={!errors.categoryId}>
                                        <option>Choose category</option>
                                        {categories.map(
                                            category => (
                                                <option value={category.id} key={category.id}>
                                                    {category.name}
                                                </option>
                                            )
                                        )}
                                    </Form.Select>
                                    <Form.Control.Feedback type="valid">
                                        Look good
                                    </Form.Control.Feedback>
                                    <Form.Control.Feedback type="invalid" className="d-block">
                                        {errors.categoryId}
                                    </Form.Control.Feedback>
                                </Form.Group>

                                <Button variant="primary" type="submit">
                                    Submit
                                </Button>
                            </Col>
                        </Row>
                    </Form>
                )}
            </Formik>
        </div>
    );
};

export default BookUpdatePage;
